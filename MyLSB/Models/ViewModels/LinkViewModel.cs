﻿using MyLSB.Repository;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Models
{
    public class LinkViewModel
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewTab { get; set; }
        public string AriaLabel { get; set; }
        public string IconClass { get; set; }
        public string IconImage { get; set; }
        public IEnumerable<LinkViewModel> Children { get; set; }

        protected LinkViewModel(Link link)
        {
        }

        public static LinkViewModel GetViewModel(Link link)
        {
            return new LinkViewModel(link)
            {
                Text = link.Fields.Text,
                Url = link.Fields.Url,
                NewTab = link.Fields.NewTab,
                AriaLabel = link.Fields.AriaLabel,
                IconClass = link.Fields.IconClass,
                IconImage = link.Fields.IconImage
            };
        }

        public static LinkViewModel GetViewModel(Link link, LinkRepository linkRepository)
        {
            return new LinkViewModel(link)
            {
                Text = link.Fields.Text,
                Url = link.Fields.Url,
                NewTab = link.Fields.NewTab,
                AriaLabel = link.Fields.AriaLabel,
                IconClass = link.Fields.IconClass,
                IconImage = link.Fields.IconImage,
                Children = linkRepository.GetLinks(link.NodeAliasPath).Select(link => GetViewModel(link, linkRepository)) ?? Enumerable.Empty<LinkViewModel>()
            };
        }
    }
}
