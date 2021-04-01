using CMS;
using CMS.Core;
using CMS.DataEngine;
using CMS.OnlineForms;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(Custom.FormHandlerModule))]

namespace Custom
{
    public class FormHandlerModule : Module
    {
        // Module class constructor, the system registers the module under the name "CustomFormHandlers"
        public FormHandlerModule()
            : base("CustomFormHandlers")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            // Assigns a handler to the BizFormItemEvents.Insert.After event
            // This event occurs after the creation of every new form record
            BizFormItemEvents.Insert.After += FormItem_InsertAfterHandler;
        }

        // Handles the form data when users create new records for the 'ContactUs' form
        private void FormItem_InsertAfterHandler(object sender, BizFormItemEventArgs e)
        {
            IEventLogService eventLog = Service.Resolve<IEventLogService>();

            // In case of database outage, the system buffers all logged events in-memory until the database is available.
            // You do not need to buffer or check for database availability in custom code.

            // Logs an information event into the event log
            eventLog.LogInformation("API Example Info", "APIEXAMPLE", eventDescription: "Test information event.");
        }
    }
}
