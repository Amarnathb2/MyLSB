using CMS.Core;
using CMS.DataEngine;
using CMS.OnlineForms;
using CMS.SiteProvider;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Controllers
{
    public class ChangeOrderRequestFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChangeOrderRequestFormViewModel obj)
        {
            BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo("ChangeOrderRequest", SiteContext.CurrentSiteID);

            if (formObject != null)
            {
                DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(formObject.FormClassID);
                string formClassName = formClass.ClassName;

                BizFormItem newFormItem = BizFormItem.New(formClassName);

                newFormItem.SetValue("NameOfBusiness", obj.NameOfBusiness);
                newFormItem.SetValue("NameOfRequestingIndividual", obj.NameOfRequestingIndividual);
                newFormItem.SetValue("PhoneNumber", obj.PhoneNumber);
                newFormItem.SetValue("LastFourOfAccountNumber", obj.LastFourOfAccountNumber);
                newFormItem.SetValue("Funding", obj.Funding);
                newFormItem.SetValue("BankLocationForPickup", obj.BankLocationForPickup);
                newFormItem.SetValue("EarliestRequestedDateForPickup", obj.EarliestRequestedDateForPickup);
                newFormItem.SetValue("EarliestRequestedTimeForPickup", obj.EarliestRequestedTimeForPickup);
                newFormItem.SetValue("TransportByPreArrangedArmoredCar", obj.TransportByPreArrangedArmoredCar);
                newFormItem.SetValue("Pennies", obj.Pennies);
                newFormItem.SetValue("Nickles", obj.Nickles);
                newFormItem.SetValue("Dimes", obj.Dimes);
                newFormItem.SetValue("Quarters", obj.Quarters);
                newFormItem.SetValue("Halves", obj.Halves);
                newFormItem.SetValue("DollarCoins", obj.DollarCoins);
                newFormItem.SetValue("Dollars", obj.Dollars);
                newFormItem.SetValue("Fives", obj.Fives);
                newFormItem.SetValue("Tens", obj.Tens);
                newFormItem.SetValue("Twenties", obj.Twenties);
                newFormItem.SetValue("Fifties", obj.Fifties);
                newFormItem.SetValue("Hundreds", obj.Hundreds);
                newFormItem.SetValue("TotalCoin", obj.TotalCoin);
                newFormItem.SetValue("TotalCurrency", obj.TotalCurrency);
                newFormItem.SetValue("TotalChangeOrder", obj.TotalChangeOrder);

                newFormItem.Insert();

                IBizFormMailSenderFactory senderFactory = Service.Resolve<IBizFormMailSenderFactory>();
                IBizFormMailSender sender = senderFactory.GetFormMailSender(formObject, newFormItem);

                // Sends a notification email to users (as specified on the form's 'Email notification' tab)
                sender.SendNotificationEmail();

                // Sends a confirmation email to the submitter (based on the form's autoresponder settings)
                sender.SendConfirmationEmail();
            }

            return Redirect(obj.ConfirmationPage);
        }
    }
}
