using MyLSB.Controllers;
using MyLSB.Models.Pages;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using MyLSB.Repository;

[assembly: RegisterPageRoute(PageDefault.CLASS_NAME, typeof(PageDefaultController))]
[assembly: RegisterPageRoute(PageRedirect.CLASS_NAME, typeof(PageRedirectController))]
namespace MyLSB.Controllers
{
    public class PageDefaultController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly SettingsRepository settingsRepository;
        private readonly PageRepository pageRepository;
        private readonly PartialsRepository partialsRepository;

        public PageDefaultController(IPageDataContextRetriever pageDataContextRetriever, SettingsRepository settingsRepository, PageRepository pageRepository, PartialsRepository partialsRepository)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.settingsRepository = settingsRepository;
            this.pageRepository = pageRepository;
            this.partialsRepository = partialsRepository;
        }

        public ActionResult Index()
        {
            var pageDefault = pageDataContextRetriever.Retrieve<PageDefault>().Page;
            var settings = settingsRepository.GetSettings();
            var viewModel = new PageDefaultViewModel(pageDefault, settings, pageRepository, partialsRepository);
            return View("~/Views/Pages/Default.cshtml", viewModel);
        }
    }

    public class PageRedirectController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;

        public PageRedirectController(IPageDataContextRetriever pageDataContextRetriever)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
        }

        public ActionResult Index()
        {
            var redirect = pageDataContextRetriever.Retrieve<PageRedirect>().Page.PageRedirectUrl;
            return Redirect(redirect);
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
