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
                Heading = masthead.Fields.Heading,
                Image = masthead.Fields.Image,
                Link1 = LinkViewModel.GetViewModel(masthead.Fields.CTA1Text, masthead.Fields.CTA1Url, masthead.Fields.CTA1NewTab, masthead.Fields.CTA1AriaLabel),
                Link2 = LinkViewModel.GetViewModel(masthead.Fields.CTA2Text, masthead.Fields.CTA2Url, masthead.Fields.CTA2NewTab, masthead.Fields.CTA2AriaLabel),
            };
        }
    }
}

