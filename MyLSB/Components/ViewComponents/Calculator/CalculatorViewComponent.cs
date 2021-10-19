using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CalculatorViewComponent : ViewComponent
    {
        public CalculatorViewComponent()
        {
        }

        public IViewComponentResult Invoke(Calculator node)
        {
            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/Calculator/CalculatorContainer.cshtml", node);
            }
            return View("~/Components/ViewComponents/Calculator/Calculator.cshtml", node);
        }
    }
}
