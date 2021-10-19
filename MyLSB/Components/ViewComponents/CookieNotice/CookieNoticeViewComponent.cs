using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CookieNoticeViewComponent : ViewComponent
    {
        private readonly SettingsRepository settingsRepository;

        public CookieNoticeViewComponent(SettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public IViewComponentResult Invoke()
        {
            if (Request.Cookies["CookieNoticeAccepted"] != null && Request.Cookies["CookieNoticeAccepted"] == "true")
            {
                return Content(String.Empty);                
            }

            var settings = settingsRepository.GetSettings();
            return View("~/Components/ViewComponents/CookieNotice/CookieNotice.cshtml", settings.CookieNotice);
        }
    }
}