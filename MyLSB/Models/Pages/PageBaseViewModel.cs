using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Routing;
using MyLSB.Repository;
using System.Collections.Generic;

namespace MyLSB.Models.Pages
{
    public abstract class PageBaseViewModel
    {
        //General
        public string ClassName { get; set; }
        public int NodeID { get; set; }
        public string PageUrl { get; set; }
        public string NodeAliasPath { get; set; }
        public string LinkedNodeAliasPath { get; set; }
        public string OpenGraphTitle { get; set; }
        public string OpenGraphType { get; set; }
        public string OpenGraphDescription { get; set; }
        public string OpenGraphImage { get; set; }
        public string OpenGraphImageAlt { get; set; }
        public string OpenGraphUrl { get; set; }
        public string Schema { get; set; }
        public string BodyClass { get; set; }
        public string PartialsPath { get; set; }

        //Settings
        public string ContactPageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberTelLink { get; set; }
        public string PrivilegedStatusUrl { get; set; }

        public PageBaseViewModel(TreeNode node, Settings settings, PageRepository pageRepository, PartialsRepository partialsRepository)
        {
            ClassName = node.ClassName;
            NodeID = node.NodeID;
            PageUrl = DocumentURLProvider.GetUrl(node);
            NodeAliasPath = node.NodeAliasPath;
            LinkedNodeAliasPath = node.IsLink ? pageRepository.GetNodeAliasPath(node.NodeLinkedNodeID) : null;
            OpenGraphTitle = node.GetStringValue("OpenGraphTitle", node.DocumentName);
            OpenGraphType = node.GetStringValue("OpenGraphType", "website");
            OpenGraphDescription = node.GetStringValue("OpenGraphDescription", node.DocumentPageDescription);
            OpenGraphImage = URLHelper.GetAbsoluteUrl(node.GetStringValue("OpenGraphImage", "~/MyLSB/media/Images/opengraph.jpg"));
            OpenGraphImageAlt = node.GetStringValue("OpenGraphImageAlt", "Lincoln Savings Bank");
            OpenGraphUrl = DocumentURLProvider.GetAbsoluteUrl(node);
            Schema = node.GetStringValue("Schema", "");
            PartialsPath = partialsRepository.GetPartialsContainerPath(node);

            ContactPageUrl = settings.ContactPageUrl;
            PhoneNumber = settings.PhoneNumber;
            PhoneNumberTelLink = settings.PhoneNumber
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace(" ", "");
            PrivilegedStatusUrl = settings.FooterPrivilegedStatusUrl;
        }
    }
}