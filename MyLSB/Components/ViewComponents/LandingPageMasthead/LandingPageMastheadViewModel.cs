using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;

namespace MyLSB.Components
{
    public class LandingPageMastheadViewModel : TreeNodeViewModel
    {
        public string Heading { get; set; }
        public string Subheading { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public LinkViewModel Button1 { get; set; }
        public LinkViewModel Button2 { get; set; }

        protected LandingPageMastheadViewModel(TreeNode node) : base(node)
        {
        }

        public static LandingPageMastheadViewModel GetViewModel(LandingPageMasthead landingPageMasthead)
        {
            return new LandingPageMastheadViewModel(landingPageMasthead)
            {
                Heading = landingPageMasthead.LandingPageMastheadHeading,
                Subheading = landingPageMasthead.LandingPageMastheadSubheading,
                Text = landingPageMasthead.LandingPageMastheadText,
                Image = landingPageMasthead.LandingPageMastheadImage,
                Button1 = LinkViewModel.GetViewModel(landingPageMasthead.LandingPageMastheadCTA1Text, landingPageMasthead.LandingPageMastheadCTA1Url, landingPageMasthead.LandingPageMastheadCTA1NewTab, landingPageMasthead.LandingPageMastheadCTA1AriaLabel),
                Button2 = LinkViewModel.GetViewModel(landingPageMasthead.LandingPageMastheadCTA2Text, landingPageMasthead.LandingPageMastheadCTA2Url, landingPageMasthead.LandingPageMastheadCTA2NewTab, landingPageMasthead.LandingPageMastheadCTA2AriaLabel)
            };
        }
    }
}

