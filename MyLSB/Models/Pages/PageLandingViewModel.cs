using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Models.Pages
{
    public class PageLandingViewModel : PageBaseViewModel
    {
        public IEnumerable<LinkViewModel> FooterNav { get; set; }

        public PageLandingViewModel(PageLanding page, Settings settings, PageRepository pageRepository, PartialsRepository partialsRepository, LinkRepository linkRepository) : base(page, settings, pageRepository, partialsRepository)
        {
            FooterNav = linkRepository.GetLinks(ContentItemIdentifiers.LANDING_FOOTER_NAVIGATION).Select(link => LinkViewModel.GetViewModel(link));
        }
    }
}