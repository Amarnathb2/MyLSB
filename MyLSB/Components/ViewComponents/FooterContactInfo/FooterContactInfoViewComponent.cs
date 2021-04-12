using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class FooterContactInfoViewComponent : ViewComponent
    {
        private readonly SettingsRepository settingsRepository;

        public FooterContactInfoViewComponent(SettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var settings = settingsRepository.GetSettings();

            return View("~/Components/ViewComponents/FooterContactInfo/FooterContactInfo.cshtml", settings);
        }
    }
}
