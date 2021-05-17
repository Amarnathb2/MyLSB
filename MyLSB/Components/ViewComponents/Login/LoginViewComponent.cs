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
        public IViewComponentResult Invoke()
        {
            return View("~/Components/ViewComponents/Login/Login.cshtml");
        }
    }
}
