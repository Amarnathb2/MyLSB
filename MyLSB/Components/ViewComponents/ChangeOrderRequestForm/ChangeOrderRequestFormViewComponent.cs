using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Models.ViewModels;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class ChangeOrderRequestFormViewComponent : ViewComponent
    {

        public ChangeOrderRequestFormViewComponent()
        {
            
        }

        public IViewComponentResult Invoke(ChangeOrderRequestForm node)
        {
            

            return View("~/Components/ViewComponents/ChangeOrderRequestForm/ChangeOrderRequestForm.cshtml", new ChangeOrderRequestFormViewModel(node));
        }
    }
}
