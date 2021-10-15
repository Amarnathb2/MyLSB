using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.Search;
using HtmlAgilityPack;
using System.Web;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(CustomSearchCrawlerModule))]

public class CustomSearchCrawlerModule : Module
{
    // Module class constructor, the system registers the module under the name "CustomSearchCrawler"
    public CustomSearchCrawlerModule()
        : base("CustomSearchCrawler")
    {
    }

    // Contains initialization code that is executed when the application starts
    protected override void OnInit()
    {
        base.OnInit();

        // Assigns a handler for the OnHtmlToPlainText event
        SearchCrawler.OnHtmlToPlainText += new SearchCrawler.HtmlToPlainTextHandler(SearchHelper_OnHtmlToPlainText);
    }

    // Add your custom HTML processing actions and return the result as a string
    static string SearchHelper_OnHtmlToPlainText(string plainText, string originalHtml)
    {

        //string outputResult = originalHtml;

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(originalHtml);
        var excludedNodes = doc.DocumentNode.SelectNodes("//*[@data-noindex]");
        if (excludedNodes != null)
        {
            foreach (HtmlNode node in excludedNodes)
            {
                node.Remove();
            }
        }

        string outputResult = doc.DocumentNode.InnerHtml;

        // Removes new line entities
        outputResult = outputResult.Replace("\n", " ");

        // Removes tab spaces
        outputResult = outputResult.Replace("\t", " ");

        // Removes JavaScript
        outputResult = HTMLHelper.RegexHtmlToTextScript.Replace(outputResult, " ");

        // Removes tags
        outputResult = HTMLHelper.RegexHtmlToTextTags.Replace(outputResult, " ");

        // Decodes HTML entities
        outputResult = HttpUtility.HtmlDecode(outputResult);

        return outputResult;
    }
}