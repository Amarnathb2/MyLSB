using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly SettingsRepository settingsRepository;

        public LoginViewComponent(SettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var settings = settingsRepository.GetSettings();
            var model = CacheHelper.Cache(cs =>
            {
                var promo = settings.Fields.LoginPromo.OfType<ProductServicePromo>().FirstOrDefault();

                if (cs.Cached)
                {
                    var cacheKeys = new string[] {
                        $"nodeid|{settings.NodeID}",
                        $"nodeid|{promo.NodeID}"
                    };
                    cs.CacheDependency = CacheHelper.GetCacheDependency(cacheKeys);
                }

                return promo;

            }, new CacheSettings(10, $"LoginPromo|{settings.NodeID}"));

            return View("~/Components/ViewComponents/Login/Login.cshtml", model);
        }
    }
}
