using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System;
using System.Collections.Generic;

namespace MyLSB.Models.Pages
{
    public class PageDefaultViewModel : PageBaseViewModel
    {

        public PageDefaultViewModel(PageDefault page, Settings settings, PageRepository pageRepository, PartialsRepository partialsRepository) : base(page, settings, pageRepository, partialsRepository)
        {            
        }
    }
}