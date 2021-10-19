using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MyLSB.TagHelpers
{

    public class JsTagHelper : TagHelper
    {
        public static IConfigurationRoot Configuration;

        public string Path { get; set; }
        public bool Version { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            string Src = Version ? Path + "?v=" + Configuration["AssetsVersion"] : Path;

            output.TagName = "script";
            output.Attributes.SetAttribute("src", Src);
        }
    }
}