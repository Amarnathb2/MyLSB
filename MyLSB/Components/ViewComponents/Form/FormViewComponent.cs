using MyLSB.Models;
using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class FormViewComponent : ViewComponent
    {
        public FormViewComponent()
        {
        }

        public IViewComponentResult Invoke(Form node)
        {
            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/Form/FormContainer.cshtml", node);
            }
            return View("~/Components/ViewComponents/Form/Form.cshtml", node);
        }
    }
}
