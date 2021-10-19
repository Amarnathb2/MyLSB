using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class HamburgerNavViewModel
    {
        public IEnumerable<MenuItemViewModel> MenuItems { get; set; }
        public IEnumerable<LinkViewModel> AuxiliaryNavItems { get; set; }

        public static HamburgerNavViewModel GetViewModel(NavigationRepository navigationRepository, LinkRepository linkRepository)
        {
            return new HamburgerNavViewModel
            {
                MenuItems = navigationRepository.GetMenuItems("/")
                                                .Select(page => MenuItemViewModel.GetViewModel(page, navigationRepository)),

                AuxiliaryNavItems = linkRepository.GetLinks(ContentItemIdentifiers.AUXILIARY_NAVIGATION)
                                                  .Select(link => LinkViewModel.GetViewModel(link))
            };
        }
    }
}
