using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.EventLog;
using MyLSB.Repository;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MyLSB.Modules.Hubspot
{
    public class HubspotAPI
    {
        private readonly string blogPostsAPIUrl;
        private readonly string blogTagsAPIUrl;
        private readonly string apiKey;
        private readonly int noOfPosts;
        public HubspotAPI(string blogPostsAPIUrl, string blogTagsAPIUrl, string apiKey, int noOfPosts)
        {
            this.blogPostsAPIUrl = !string.IsNullOrEmpty(blogPostsAPIUrl) ? blogPostsAPIUrl : "https://api.hubapi.com/cms/v3/blogs/posts";
            this.blogTagsAPIUrl = !string.IsNullOrEmpty(blogTagsAPIUrl) ? blogTagsAPIUrl : "https://api.hubapi.com/cms/v3/blogs/tags";
            this.apiKey = !string.IsNullOrEmpty(apiKey) ? apiKey : "53026761-e9d3-4706-a72c-bf91a6156387";
            this.noOfPosts = noOfPosts == 0 ? 3 : noOfPosts;
        }
        public List<BlogPost> GetBlogPosts()
        {
            List<BlogPost> lstBlogPosts = new List<BlogPost>();
            try
            {
                if (noOfPosts > 0)
                {

                    Int64 offsetValue = GetOffsetValue();

                    var blogPosts = GetLatestBlogPosts(offsetValue);
                    if (blogPosts?.Any() ?? false)
                    {
                        blogPosts.Reverse();
                        lstBlogPosts.AddRange(blogPosts);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("Hubspot API", "Exception", ex);
            }
            return lstBlogPosts;
        }
        /// <summary>
        /// Get Latest Count of Blog Posts from the Hubspot API
        /// </summary>
        /// <param name="offsetValue">offset value to get the latest items from API</param>
        /// <returns>List of Blog Post articles</returns>
        private List<BlogPost> GetLatestBlogPosts(Int64 offsetValue)
        {
            List<BlogPost> lstBlogPosts = new List<BlogPost>();

            string apiBaseBlogPostURL = $"{blogPostsAPIUrl}?hapikey={apiKey}";
            //Request to Get the Latest Number of Blog Posts
            var postsClientRequest = new RestClient($"{apiBaseBlogPostURL}&sort=publishDate&limit={noOfPosts}&state=PUBLISHED&offset={offsetValue}");
            postsClientRequest.Timeout = -1;
            var postsRequest = new RestRequest(Method.GET);
            IRestResponse postsResponse = postsClientRequest.Execute(postsRequest);
            JObject postsJobject = JObject.Parse(postsResponse.Content);
            JArray arrBlogPosts = (JArray)postsJobject["results"];


            List<string> lstTagIDs = new List<string>();
            if (arrBlogPosts != null && arrBlogPosts.Count > 0)
            {
                foreach (var blogPost in arrBlogPosts)
                {

                    BlogPost post = new BlogPost()
                    {
                        Name = blogPost["htmlTitle"].ToString(),
                        URL = blogPost["url"].ToString()
                    };
                    var arrTagIds = blogPost["tagIds"].ToArray();
                    foreach (var tag in arrTagIds)
                    {
                        post.Tags.Add(new BlogTag { TagID = Convert.ToInt64(tag) });
                        lstTagIDs.Add(tag.ToString());
                    }
                    lstBlogPosts.Add(post);
                }
            }
            List<BlogTag> lstTags = GetTagsData(lstTagIDs);
            if (lstTags?.Any() ?? false)
            {
                foreach (var bp in lstBlogPosts)
                {
                    foreach (var tag in bp.Tags)
                    {
                        var selectedTag = lstTags.Where(x => x.TagID == tag.TagID)?.FirstOrDefault();
                        if (selectedTag != null)
                        {
                            tag.TagName = selectedTag.TagName;
                        }
                    }
                }
            }
            return lstBlogPosts;
        }

        /// <summary>
        /// Get Tags Names for Blog Articles based on IDs resturned from the Posts API
        /// </summary>
        /// <param name="lstTagIDs">List of TagIDs extracted from Blog Posts</param>
        /// <returns>List of Blog Tag Objects, Returns ID and name</returns>
        private List<BlogTag> GetTagsData(List<string> lstTagIDs)
        {
            string apiBaseBlogTagsURL = $"{blogTagsAPIUrl}?hapikey={apiKey}";
            List<BlogTag> lstTags = new List<BlogTag>();
            if (lstTagIDs.Count > 0)
            {
                string idCondition = "&id__in=";
                //Request to Get the Latest Number of Blog Posts
                string tagsAPIWhereCondition = idCondition + String.Join(idCondition, lstTagIDs.Distinct());

                var tagsClientRequest = new RestClient($"{apiBaseBlogTagsURL}{tagsAPIWhereCondition}");
                tagsClientRequest.Timeout = -1;
                var tagsRequest = new RestRequest(Method.GET);
                IRestResponse tagsResponse = tagsClientRequest.Execute(tagsRequest);
                JObject tagsJobject = JObject.Parse(tagsResponse.Content);
                JArray arrtags = (JArray)tagsJobject["results"];
                if (arrtags != null && arrtags.Count > 0)
                {
                    foreach (var tag in arrtags)
                    {
                        BlogTag tagItem = new BlogTag()
                        {
                            TagID = (Int64)tag["id"],
                            TagName = tag["name"].ToString()
                        };


                        if (!lstTags.Any(x => x.TagID == tagItem.TagID))
                            lstTags.Add(tagItem);
                    }
                }
            }
            return lstTags;
        }
        /// <summary>
        /// Request to Get the Total Blog Posts over to determine the offset
        /// </summary>
        /// <param name="noOfPosts">Total Number of posts to be displayed</param>
        /// <returns>Offset Value</returns>
        private Int64 GetOffsetValue()
        {
            string apiBaseBlogPostURL = $"{blogPostsAPIUrl}?hapikey={apiKey}";
            var baseClientRequest = new RestClient(apiBaseBlogPostURL + "&sort=publishDate&limit=1&state=PUBLISHED");
            baseClientRequest.Timeout = -1;
            var baseRequest = new RestRequest(Method.GET);
            IRestResponse baseResponse = baseClientRequest.Execute(baseRequest);
            JObject baseJobject = JObject.Parse(baseResponse.Content);
            Int64 totalRecords = (Int64)((JValue)baseJobject["total"]).Value;
            return Convert.ToInt64(totalRecords - noOfPosts);
        }
    }
}
