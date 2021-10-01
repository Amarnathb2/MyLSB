using Microsoft.AspNetCore.Mvc;
using MyLSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Controllers
{
    public class ChangeOrderRequestFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChangeOrderRequestFormViewModel obj)
        {


            return Redirect(obj.ConfirmationPage);
        }
    }
}
