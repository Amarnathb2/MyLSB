using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;

namespace MyLSB.Models.FormBuilder.FormComponents.FormComponentProperties
{
    public class Html5InputComponentProperties : FormComponentProperties<string>
    {
        // Sets the component as the editing component of its DefaultValue property
        // System properties of the specified editing component, such as the Label, Tooltip, and Order, remain set to system defaults unless explicitly set in the constructor
        [DefaultValueEditingComponent(TextInputComponent.IDENTIFIER)]
        public override string DefaultValue { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Input type", DefaultValue = "text", Tooltip = "Enter the HTML 5 input type")]
        public string Type { get; set; }

        // Defines a custom property and its editing component
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Autocomplete", DefaultValue = "", Tooltip = "Enter the input purpose keyword if applicable.")]
        public string Autocomplete { get; set; }

        // Defines a custom property and its editing component
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Placeholder", DefaultValue = "", Tooltip = "Enter the input placeholder if applicable.")]
        public override string Placeholder { get; set; }

        // Initializes a new instance of the Html5InputComponentProperties class and configures the underlying database field
        public Html5InputComponentProperties()
            : base(FieldDataType.Text, 200)
        {
        }
    }
}