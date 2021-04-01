using Kentico.Forms.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterFormSection("TwoColumnFormSection", "Two Columns", customViewName: "~/Views/Shared/FormSections/_TwoColumnFormSection.cshtml", Description = "Place any form controls you need such as an HTML5 Input into one of two columns", IconClass = "icon-l-cols-2")]

namespace MyLSB.Controllers.FormSections
{
    public class TwoColumnFormSectionController : Controller
    {
        // Action used to retrieve the section markup
        public ActionResult Index()
        {
            return PartialView("FormSections/_TwoColumnFormSection");
        }
    }
}
