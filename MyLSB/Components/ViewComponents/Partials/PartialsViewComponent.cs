using MyLSB.Repository;
using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components.ViewComponents
{
    public class PartialsViewComponent : ViewComponent
    {
        private readonly PartialsRepository partialRepository;

        public PartialsViewComponent(PartialsRepository partialRepository)
        {
            this.partialRepository = partialRepository;
        }

        public IViewComponentResult Invoke(string path, bool getContainer)
        {
            var partialsPath = path;

            if (getContainer)
            {
                var container = partialRepository.GetPartialsContainer(path);

                if (container == null)
                {
                    return Content(string.Empty);
                }

                partialsPath = container.NodeAliasPath;
            }

            var partials = partialRepository.GetPartials(partialsPath);

            return View("~/Components/ViewComponents/Partials/Partials.cshtml", partials);
        }
    }
}
