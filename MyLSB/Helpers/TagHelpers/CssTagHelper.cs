using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MyLSB.TagHelpers
{

    public class CssTagHelper : TagHelper
    {
        public static IConfigurationRoot Configuration;

        public string Path { get; set; }
        public bool Version { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            string Href = Version ? Path + "?v=" + Configuration["AssetsVersion"] : Path;

            output.TagName = "link";
            output.Attributes.SetAttribute("href", Href);
            output.Attributes.SetAttribute("rel", "stylesheet");
        }
    }
}