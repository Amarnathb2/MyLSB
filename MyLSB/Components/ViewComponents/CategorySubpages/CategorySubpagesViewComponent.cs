using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Components
{
    public class CategorySubpagesViewComponent : ViewComponent
    {
        private readonly NavigationRepository navigationRepository;

        public CategorySubpagesViewComponent(NavigationRepository navigationRepository)
        {
            this.navigationRepository = navigationRepository;
        }

        public IViewComponentResult Invoke(CategorySubpages node)
        {
            List<CategorySubpageItemViewModel> pages = new List<CategorySubpageItemViewModel>();

            if (node.CategorySubpagesDisplay == "path")
            {
                foreach (var item in navigationRepository.GetMenuItems(node.CategorySubpagesPath))
                {
                    pages.Add(CategorySubpageItemViewModel.GetViewModel(item));
                }
            }
            else if (node.CategorySubpagesDisplay == "pages")
            {
                pages = CacheHelper.Cache(cs =>
                {
                    var selectedPages = node.Fields.Pages;

                    if (cs.Cached)
                    {
                        var cacheKeys = new List<string>() { $"nodeid|{node.NodeID}" };

                        foreach (var page in selectedPages)
                        {
                            cacheKeys.Add($"nodeid|{page.NodeID}");
                        }
                        cs.CacheDependency = CacheHelper.GetCacheDependency(cacheKeys);
                    }

                    return selectedPages.Select(node => CategorySubpageItemViewModel.GetViewModel(node))
                                        .ToList();

                }, new CacheSettings(10, $"{nameof(CategorySubpagesViewComponent)}|{node.NodeID}"));
            }


            if (pages.Any())
            {
                return View("~/Components/ViewComponents/CategorySubpages/CategorySubpages.cshtml", pages);
            }

            return Content(String.Empty);
        }
    }
}
