using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class ProductsServicesViewComponent : ViewComponent
    {
        private readonly ProductsServicesRepository productsServicesRepository;

        public ProductsServicesViewComponent(ProductsServicesRepository productsServicesRepository)
        {
            this.productsServicesRepository = productsServicesRepository;
        }

        public IViewComponentResult Invoke(ProductsServices node)
        {
            var model = ProductsServicesViewModel.GetViewModel(node, productsServicesRepository);

            if (model.Tabs.Any())
            {
                return View("~/Components/ViewComponents/ProductsServices/ProductsServices.cshtml", model);
            }
            return Content(String.Empty);
        }
    }
}