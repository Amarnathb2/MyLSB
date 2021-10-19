using MyLSB.Models;
using MyLSB.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class SpeedbumpViewComponent : ViewComponent
    {
        private readonly SettingsRepository settingsRepository;

        public SpeedbumpViewComponent(SettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = SpeedbumpViewModel.GetViewModel(settingsRepository);

            return View("~/Components/ViewComponents/Speedbump/Speedbump.cshtml", model);
        }
    }
}
