using System.Linq;
using MyLSB.Models;
using MyLSB.Repository;

using Microsoft.AspNetCore.Mvc;
using CMS.DocumentEngine.Types.Custom;
using System.Collections.Generic;

namespace MyLSB.ViewComponents
{
    public class AlertsViewComponent : ViewComponent
    {
        private readonly AlertRepository alertRepository;

        public AlertsViewComponent(AlertRepository alertRepository)
        {
            this.alertRepository = alertRepository;
        }

        public IViewComponentResult Invoke()
        {
            var alerts = new List<Alert>();

            foreach (var alert in alertRepository.GetAlerts())
            {
                if (Request.Cookies[$"AlertDismissed-{alert.AlertID}"] != null && Request.Cookies[$"AlertDismissed-{alert.AlertID}"] == "true")
                {
                    continue;
                }
                alerts.Add(alert);
            }

            return View("~/Components/ViewComponents/Alerts/Alerts.cshtml", alerts);
        }
    }
}
