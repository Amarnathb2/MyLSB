using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class MastheadViewModel
    {
        public string Heading { get; set; }
        public string Image { get; set; }
        public LinkViewModel Link1 { get; set; }
        public LinkViewModel Link2 { get; set; }

        public static MastheadViewModel GetViewModel(Masthead masthead)
        {
            return new MastheadViewModel
            {
                Heading = masthead.MastheadHeading,
                Image = masthead.MastheadImage,
                Link1 = LinkViewModel.GetViewModel(masthead.MastheadCTA1Text, masthead.MastheadCTA1Url, masthead.MastheadCTA1NewTab, masthead.MastheadCTA1AriaLabel),
                Link2 = LinkViewModel.GetViewModel(masthead.MastheadCTA2Text, masthead.MastheadCTA2Url, masthead.MastheadCTA2NewTab, masthead.MastheadCTA2AriaLabel)
            };
        }
    }
}

