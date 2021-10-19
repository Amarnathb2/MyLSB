using Microsoft.AspNetCore.Html;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class SpeedbumpViewModel
    {
        public HtmlString Title { get; set; }
        public string Message { get; set; }
        public HtmlString Whitelist { get; set; }

        public static SpeedbumpViewModel GetViewModel(SettingsRepository settingsRepository)
        {
            var settings = settingsRepository.GetSettings();

            return new SpeedbumpViewModel
            {
                Title = new HtmlString(settings.SpeedbumpTitle),
                Message = settings.SpeedbumpMessage,
                Whitelist = new HtmlString($"[\"{ settings.SpeedbumpWhitelist.Replace(Environment.NewLine, "\", \"").Replace(" ", "") }\"]")
            };
        }
    }
}
