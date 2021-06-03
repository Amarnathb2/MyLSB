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
[assembly: RegisterPageRoute(PageLocation.CLASS_NAME, typeof(PageLocationController))]
[assembly: RegisterPageRoute(PageEmployee.CLASS_NAME, typeof(PageEmployeeController))]
[assembly: RegisterPageRoute(PageLanding.CLASS_NAME, typeof(PageLandingController))]
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

    public class PageLocationController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly SettingsRepository settingsRepository;
        private readonly PageRepository pageRepository;
        private readonly PartialsRepository partialsRepository;

        public PageLocationController(IPageDataContextRetriever pageDataContextRetriever, SettingsRepository settingsRepository, PageRepository pageRepository, PartialsRepository partialsRepository)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.settingsRepository = settingsRepository;
            this.pageRepository = pageRepository;
            this.partialsRepository = partialsRepository;
        }

        public ActionResult Index()
        {
            var pageLocation = pageDataContextRetriever.Retrieve<PageLocation>().Page;
            var settings = settingsRepository.GetSettings();
            var viewModel = new PageLocationViewModel(pageLocation, settings, pageRepository, partialsRepository);
            return View("~/Views/Pages/Location.cshtml", viewModel);
        }
    }

    public class PageEmployeeController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly SettingsRepository settingsRepository;
        private readonly PageRepository pageRepository;
        private readonly PartialsRepository partialsRepository;

        public PageEmployeeController(IPageDataContextRetriever pageDataContextRetriever, SettingsRepository settingsRepository, PageRepository pageRepository, PartialsRepository partialsRepository)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.settingsRepository = settingsRepository;
            this.pageRepository = pageRepository;
            this.partialsRepository = partialsRepository;
        }

        public ActionResult Index()
        {
            var pageEmployee = pageDataContextRetriever.Retrieve<PageEmployee>().Page;

            if (pageEmployee.EmployeeDisableFullBio)
            {
                return new RedirectResult("/Page-Not-Found", false);
            }

            var settings = settingsRepository.GetSettings();
            var viewModel = new PageEmployeeViewModel(pageEmployee, settings, pageRepository, partialsRepository);

            return View("~/Views/Pages/Employee.cshtml", viewModel);
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

    public class PageLandingController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly SettingsRepository settingsRepository;
        private readonly PageRepository pageRepository;
        private readonly PartialsRepository partialsRepository;
        private readonly LinkRepository linkRepository;

        public PageLandingController(IPageDataContextRetriever pageDataContextRetriever, SettingsRepository settingsRepository, PageRepository pageRepository, PartialsRepository partialsRepository, LinkRepository linkRepository)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.settingsRepository = settingsRepository;
            this.pageRepository = pageRepository;
            this.partialsRepository = partialsRepository;
            this.linkRepository = linkRepository;
        }


        public ActionResult Index()
        {
            var pageDefault = pageDataContextRetriever.Retrieve<PageLanding>().Page;
            var settings = settingsRepository.GetSettings();
            var viewModel = new PageLandingViewModel(pageDefault, settings, pageRepository, partialsRepository, linkRepository);
            return View("~/Views/Pages/Landing.cshtml", viewModel);
        }
    }
}
