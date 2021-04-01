using Kentico.Forms.Web.Mvc;
using Kentico.Forms.Web.Mvc.Widgets;

namespace MyLSB.FormBuilder.FormBuilderCustomizations
{
    public class FormBuilderStaticMarkupConfiguration
    {
        public static void SetGlobalRenderingConfigurations()
        {
            // Sets a new rendering configuration for the 'Form' widget, adding attributes
            // to the form element and the submit button and wrapping the form in two 'div' blocks
            FormWidgetRenderingConfiguration.Default = new FormWidgetRenderingConfiguration
            {
                // Elements wrapping the Form element
                //FormWrapperConfiguration = new FormWrapperRenderingConfiguration
                //{
                //    ElementName = "div",
                //    HtmlAttributes = { { "class", "" } }
                //},

                // The form itself HTML attributes
                FormHtmlAttributes = { { "class", "kentico-form kentico-form-loaded" }, { "novalidate", "" } },

                // Submit button HTML attributes
                SubmitButtonHtmlAttributes = { { "class", "btn btn-primary" } },


            };
        }
    }
}