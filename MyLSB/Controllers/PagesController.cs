using MyLSB.Controllers;
using MyLSB.Models.Pages;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Threading;


[assembly: RegisterPageRoute(PageDefault.CLASS_NAME, typeof(PageDefaultController))]
namespace MyLSB.Controllers
{
    public class PageDefaultController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;

        public PageDefaultController(IPageDataContextRetriever pageDataContextRetriever)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
        }

        public ActionResult Index()
        {
            var pageDefault = pageDataContextRetriever.Retrieve<PageDefault>().Page;
            var viewModel = new PageDefaultViewModel(pageDefault);
            return View("~/Views/Pages/Default.cshtml", viewModel);
        }
    }

    //public class PageLandingController : Controller
    //{
    //    private readonly IPageDataContextRetriever pageDataContextRetriever;

    //    public PageLandingController(
    //        IPageDataContextRetriever pageDataContextRetriever
    //    )
    //    {
    //        this.pageDataContextRetriever = pageDataContextRetriever;
    //    }

    //    public ActionResult Index(CancellationToken cancellationToken)
    //    {
    //        var pageLanding = pageDataContextRetriever.Retrieve<PageLanding>().Page;
    //        var viewModel = new Models.PageBaseViewModel(pageLanding);
    //        return View("/Views/Pages/Landing.cshtml", viewModel);
    //    }
    //}
}
