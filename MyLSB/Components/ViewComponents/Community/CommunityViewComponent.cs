using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CommunityViewComponent : ViewComponent
    {
        private readonly StatisticRepository statisticRepository;

        public CommunityViewComponent(StatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public IViewComponentResult Invoke(Community node)
        {
            var model = CommunityViewModel.GetViewModel(node, statisticRepository);
            return View("~/Components/ViewComponents/Community/Community.cshtml", model);
        }
    }
}