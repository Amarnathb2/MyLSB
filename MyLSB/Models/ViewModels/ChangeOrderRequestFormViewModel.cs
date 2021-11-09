using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Models.ViewModels
{
    public class ChangeOrderRequestFormViewModel
    {
        public List<SelectListItem> FundingItems
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Selected = true, Text = "Select One", Value = ""},
                    new SelectListItem { Selected = false, Text = "Debit my Account", Value = "Debit my Account"},
                    new SelectListItem { Selected = false, Text = "Exchange at Pickup", Value = "Exchange at Pickup"}
                };
            }
        }

        public List<SelectListItem> BankLocationForPickupItems
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Selected = true, Text = "Select One", Value = ""},
                    new SelectListItem { Selected = false, Text = "Adel", Value = "csa-adel@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Allison", Value = "csa-allison@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Ankeny", Value = "csa-ankeny@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Aplington", Value = "csa-aplington@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Cedar Falls Industrial Park", Value = "csa-cfip@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Cedar Falls Main Street", Value = "csa-cfdt@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Clive", Value = "csa-clive@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Des Moines- Ingersoll", Value = "csa-ingersoll@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Garwin", Value = "csa-garwin@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Greene", Value = "csa-greene@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Grinnell", Value = "csa-grinnell@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Hudson", Value = "csa-hudson@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Lincoln", Value = "csa-lincolngarwin@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Nashua", Value = "csa-nashua@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Reinbeck", Value = "csa-reinbeck@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Tama", Value = "csa-tama@mylsb.com"},
                    new SelectListItem { Selected = false, Text = "Waterloo", Value = "csa-waterloo@mylsb.com"}
                };
            }
        }

        [Display(Name = "Name of Business")]
        public string NameOfBusiness { get; set; }

        [Display(Name = "Name of Requesting Individual")]
        public string NameOfRequestingIndividual { get; set; }

        [Display(Name = "Last Four of Account Number")]
        public string LastFourOfAccountNumber { get; set; }

        [Display(Name = "Funding")]
        public string Funding { get; set; }

        [Display(Name = "Bank Location for Pickup")]
        public string BankLocationForPickup { get; set; }

        [Display(Name = "Earliest Requested Date for Pickup")]
        public string EarliestRequestedDateForPickup { get; set; }

        [Display(Name = "Earliest Requested Time for Pickup", Description = "Please allow at least 90 minutes from time of entry for your order to be processed.")]
        public string EarliestRequestedTimeForPickup { get; set; }

        [Display(Name = "Transport by pre-arranged Armored Car")]
        public bool TransportByPreArrangedArmoredCar { get; set; }

        [Display(Name = "Pennies", Description = "$0.50/roll")]
        public string Pennies { get; set; }

        [Display(Name = "Nickles", Description = "$2.00/roll")]
        public string Nickles { get; set; }

        [Display(Name = "Dimes", Description = "$10/roll")]
        public string Dimes { get; set; }

        [Display(Name = "Quarters", Description = "$10/roll")]
        public string Quarters { get; set; }

        [Display(Name = "Halves", Description = "$10/roll. Subject to availability.")]
        public string Halves { get; set; }

        [Display(Name = "Dollar Coins", Description = "$25/roll. Subject to availability.")]
        public string DollarCoins { get; set; }

        [Display(Name = "Dollars")]
        public string Dollars { get; set; }

        [Display(Name = "Fives")]
        public string Fives { get; set; }

        [Display(Name = "Tens")]
        public string Tens { get; set; }

        [Display(Name = "Twenties")]
        public string Twenties { get; set; }

        [Display(Name = "Fifties")]
        public string Fifties { get; set; }

        [Display(Name = "Hundreds")]
        public string Hundreds { get; set; }

        [Display(Name = "Total Coin")]
        public string TotalCoin { get; set; }

        [Display(Name = "Total Currency")]
        public string TotalCurrency { get; set; }

        [Display(Name = "Total Change Order")]
        public string TotalChangeOrder { get; set; }

        public string ConfirmationPage { get; set; }

        public ChangeOrderRequestFormViewModel()
        {
            
        }
    }
}
