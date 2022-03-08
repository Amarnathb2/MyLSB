using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components.ViewComponents
{
    public class BannerCarouselViewComponent : ViewComponent
    {
        private readonly BannerRepository bannerRepository;

        public BannerCarouselViewComponent(BannerRepository bannerRepository)
        {
            this.bannerRepository = bannerRepository;
        }

        public IViewComponentResult Invoke(BannerCarousel node)
        {
            var banners = bannerRepository.GetBanners(node.BannerCarouselPath).Select(x => BannerViewModel.GetViewModel(x));

            return View("~/Components/ViewComponents/BannerCarousel/BannerCarousel.cshtml", banners);
        }
    }
}
