using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components.ViewComponents.SeoText
{
    public class SeoTextViewComponent : ViewComponent
    {
        private readonly SettingsRepository settingsRepository;

        public SeoTextViewComponent(SettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var settings = settingsRepository.GetSettings();

            return View("~/Components/ViewComponents/SeoText/SeoText.cshtml", settings);
        }
    }
}
