using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System;
using System.Collections.Generic;

namespace MyLSB.Models.Pages
{
    public class PageLocationViewModel : PageBaseViewModel
    {
        public PageLocationViewModel(PageLocation page, Settings settings, PageRepository pageRepository, PartialsRepository partialsRepository) : base(page, settings, pageRepository, partialsRepository)
        {
        }
    }
}