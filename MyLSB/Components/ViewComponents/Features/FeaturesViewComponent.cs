using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class FeaturesViewComponent : ViewComponent
    {
        private readonly FeatureRepository featureRepository;

        public FeaturesViewComponent(FeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public IViewComponentResult Invoke(Features node)
        {
            var model = FeaturesViewModel.GetViewModel(node, featureRepository);
            return View("~/Components/ViewComponents/Features/Features.cshtml", model);
        }
    }
}