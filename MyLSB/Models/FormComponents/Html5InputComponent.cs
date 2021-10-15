using Kentico.Forms.Web.Mvc;
using MyLSB.Models.FormBuilder.FormComponents;
using MyLSB.Models.FormBuilder.FormComponents.FormComponentProperties;

[assembly: RegisterFormComponent("Html5InputComponent", typeof(Html5InputComponent), "HTML 5 input", Description = "Allows you to select HTML 5 inputs like email, phone, etc.", IconClass = "icon-l-text")]

namespace MyLSB.Models.FormBuilder.FormComponents
{
    public class Html5InputComponent : FormComponent<Html5InputComponentProperties, string>
    {
        [BindableProperty]
        public string Value { get; set; }

        public override string GetValue()
        {
            return Value;
        }

        public override void SetValue(string value)
        {
            Value = value;
        }
    }
}