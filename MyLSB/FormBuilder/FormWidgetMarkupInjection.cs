using System;

using Kentico.Forms.Web.Mvc.Widgets;

namespace MyLSB.FormBuilder.FormBuilderCustomizations
{
    public class FormWidgetMarkupInjection
    {

        public static void RegisterEventHandlers()
        {
            FormWidgetRenderingConfiguration.GetConfiguration.Execute += KenticoFormWidgetMarkupInjection;
        }


        private static void KenticoFormWidgetMarkupInjection(object sender, GetFormWidgetRenderingConfigurationEventArgs e)
        {

            // Sets additional attributes only for specific forms. Since the 'class' attribute is fairly
            // common, checks if the key is already present and inserts or appends the key accordingly.
            //if (e.Form.FormName.Equals("Feedback", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    if (e.Configuration.FormWrapperConfiguration.HtmlAttributes.ContainsKey("class"))
            //    {
            //        e.Configuration.FormWrapperConfiguration.HtmlAttributes["class"] += " feedback-form";
            //    }
            //    else
            //    {
            //        e.Configuration.FormWrapperConfiguration.HtmlAttributes["class"] = "feedback-form";
            //    }
            //}
        }
    }
}