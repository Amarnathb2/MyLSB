using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using MyLSB.Repository;
using System;
using System.Collections.Generic;

namespace MyLSB.Models.Pages
{
    public class PageEmployeeViewModel : PageBaseViewModel
    {
        public string Name { get; set; }
        public string Designations { get; set; }
        public string Title { get; set; }
        public string Specialty { get; set; }
        public string NMLS { get; set; }
        public string Photo { get; set; }
        public string Quote { get; set; }
        public string Bio {get; set;}
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Address1Secondary { get; set; }
        public string Address2Secondary { get; set; }
        public string CitySecondary { get; set; }
        public string StateSecondary { get; set; }
        public string ZipSecondary { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string ContactFormID { get; set; }
        public HubSpotForm ContactForm { get; set; }

        public bool ShowWealthManagementLogo { get; set; }

        public PageEmployeeViewModel(PageEmployee page, Settings settings, PageRepository pageRepository, PartialsRepository partialsRepository) : base(page, settings, pageRepository, partialsRepository)
        {
            Name = !String.IsNullOrEmpty(page.EmployeeDisplayName) ? page.EmployeeDisplayName : page.EmployeeName;
            Designations = page.EmployeeDesignations;
            Title = page.EmployeeTitle;
            Specialty = page.EmployeeSpecialty;
            NMLS = page.EmployeeNMLS;
            Photo = page.EmployeePhoto;
            Quote = page.EmployeeQuote;
            //Bio = page.EmployeeBio;
            Address1 = page.EmployeeAddress1;
            Address2 = page.EmployeeAddress2;
            City = page.EmployeeCity;
            State = page.EmployeeState;
            Zip = page.EmployeeZip;
            Address1Secondary = page.EmployeeAddress1Secondary;
            Address2Secondary = page.EmployeeAddress2Secondary;
            CitySecondary = page.EmployeeCitySecondary;
            StateSecondary = page.EmployeeStateSecondary;
            ZipSecondary = page.EmployeeZipSecondary;
            OfficePhone = page.EmployeeOfficePhone;
            MobilePhone = page.EmployeeMobilePhone;
            Fax = page.EmployeeFax;
            //ContactFormID = page.EmployeeContactFormID;
            //ContactForm = new HubSpotForm()
            //{
            //    HubSpotFormPortalID = "590175",
            //    HubSpotFormFormID = page.EmployeeContactFormID
            //};

            BodyClass = "employee-page";
            OpenGraphImage = URLHelper.GetAbsoluteUrl(page.GetStringValue("EmployeePhoto", "~/MyLSB/media/Images/opengraph.jpg"));
            OpenGraphImageAlt = page.GetStringValue("EmployeeName", "Lincoln Savings Bank");
            ShowWealthManagementLogo = page.GetBooleanValue("ShowWealthManagementLogo", false);
        }
    }
}