using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class FooterNavViewModel
    {
        public IEnumerable<LinkViewModel> PopularRequests { get; set; }
        public IEnumerable<LinkViewModel> LearnAboutUs { get; set; }

        public static FooterNavViewModel GetViewModel(LinkRepository linkRepository)
        {
            return new FooterNavViewModel
            {
                PopularRequests = linkRepository.GetLinks(ContentItemIdentifiers.POPULAR_REQUESTS).Select(link => LinkViewModel.GetViewModel(link)),
                LearnAboutUs = linkRepository.GetLinks(ContentItemIdentifiers.LEARN_ABOUT_US).Select(link => LinkViewModel.GetViewModel(link))
            };
        }
    }
}