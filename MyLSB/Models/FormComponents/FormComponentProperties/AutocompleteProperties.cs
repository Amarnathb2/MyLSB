using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;

namespace MyLSB.Models.FormBuilder.FormComponents
{
    public class AutocompleteProperties : FormComponentProperties<string>
    {
        // Gets or sets the default value of the form component and the underlying field
        [DefaultValueEditingComponent(TextInputComponent.IDENTIFIER)]
        public override string DefaultValue
        {
            get;
            set;
        }

        // Defines a custom property and its editing component
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Autocomplete", Tooltip = "Enter the input purpose keyword if applicable.", ExplanationText = "Sets the field's autocomplete property.")]
        public string Autocompete { get; set; }


        // Initializes a new instance of the properties class and configures the underlying database field
        public AutocompleteProperties()
            : base(FieldDataType.Text, 100)
        {
        }
    }
}
