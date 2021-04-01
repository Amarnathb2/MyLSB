using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;

namespace MyLSB.Models.FormBuilder.FormComponents
{
    public class PlaceholderProperties : FormComponentProperties<string>
    {
        // Gets or sets the default value of the form component and the underlying field
        [DefaultValueEditingComponent(TextInputComponent.IDENTIFIER)]
        public override string DefaultValue
        {
            get;
            set;
        }

        // Defines a custom property and its editing component
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Placeholder", Tooltip = "Enter the input purpose placeholder if applicable.", ExplanationText = "Sets the field's placeholder property.")]
        public string Autocompete { get; set; }


        // Initializes a new instance of the properties class and configures the underlying database field
        public PlaceholderProperties()
            : base(FieldDataType.Text, 100)
        {
        }
    }
}
