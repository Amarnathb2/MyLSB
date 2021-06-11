using Kentico.Forms.Web.Mvc;
using MyLSB.Models.FormBuilder.FormComponents;
using System;
using System.Collections.Generic;
using CMS.Helpers;
using System.Text;
using Microsoft.AspNetCore.Html;
using Kentico.Content.Web.Mvc;

namespace MyLSB.FormBuilder.FormBuilderCustomizations
{

    public class FormFieldMarkupInjection
    {
        public static void RegisterEventHandlers()
        {
            // Contextually customizes the markup of rendered form fields
            FormFieldRenderingConfiguration.GetConfiguration.Execute += FormComponentMarkupInjection;
        }

        private static void FormComponentMarkupInjection(object sender, GetFormFieldRenderingConfigurationEventArgs e)
        {
            // Assigns additional attributes fields
            AddFieldSpecificMarkup(e);

            // Assigns additional attributes to fields rendered as part of a specified form
            AddFormSpecificMarkup(e);
        }

        private static void AddFieldSpecificMarkup(GetFormFieldRenderingConfigurationEventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////
            // HTML5 INPUT, TEXTAREA, SELECT/DROPDOWN
            //////////////////////////////////////////////////////////////////////////////////////////////
            if (
                e.FormComponent is Html5InputComponent ||
                e.FormComponent is TextAreaComponent ||
                e.FormComponent is DropDownComponent)
            {
                string ComponentClasses = "form-group form-group-text";
                string ComponentErrors = "";

                if (e.FormComponent.BaseProperties.Required)
                {
                    // Adds the 'aria-required' and 'required' attributes to the component's 'input' element
                    e.Configuration.EditorHtmlAttributes["required"] = "";

                    ComponentClasses += " form-group--required";
                    ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"required\">" + e.FormComponent.BaseProperties.Label + " is a required field</li>";
                }

                // begin kentico validation rules
                if (e.FormComponent.BaseProperties.ValidationRuleConfigurations.Count > 0) {
                    foreach (var Rule in e.FormComponent.BaseProperties.ValidationRuleConfigurations)
                    {
                        if (Rule.Identifier == "Kentico.RegularExpression")
                        {
                            var validationrule = Rule.ValidationRule as RegularExpressionValidationRule;
                            string RuleType = "regex";
                            string RuleMessage = validationrule.ErrorMessage;
                            string RuleRegex = Extensions.ReplaceCtrl(validationrule.RegularExpression);
                            ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"" + RuleType + "\" data-ruleregex=\"" + RuleRegex + "\">" + RuleMessage + " </li>";
                        }

                        else if (Rule.Identifier == "Kentico.MaximumLength")
                        {
                            var validationrule = Rule.ValidationRule as MaximumLengthValidationRule;
                            string RuleType = "maxlength";
                            string RuleMessage = validationrule.ErrorMessage;
                            string RuleMax = validationrule.MaximumLength.ToString();
                            ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"" + RuleType + "\" data-rulemax=\"" + RuleMax + "\">" + RuleMessage + " </li>";
                        }

                        else if (Rule.Identifier == "Kentico.MinimumLength")
                        {
                            var validationrule = Rule.ValidationRule as MinimumLengthValidationRule;
                            string RuleType = "minlength";
                            string RuleMessage = validationrule.ErrorMessage;
                            string RuleMin = validationrule.MinimumLength.ToString();
                            ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"" + RuleType + "\" data-rulemin=\"" + RuleMin + "\">" + RuleMessage + " </li>";
                        }

                        else if (Rule.Identifier == "Kentico.StringCompareToField")
                        {
                            var validationrule = Rule.ValidationRule as StringCompareToFieldValidationRule;
                            string RuleType = "compare";
                            string RuleMessage = validationrule.ErrorMessage;
                            string RuleComparison = validationrule.ComparisonType.ToString();
                            string RuleComparisonField = validationrule.DependeeFieldGuid.ToString();
                            ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"" + RuleType + "\" data-rulecomparison=\"" + RuleComparison + "\" data-rulecomparisonfield=\"" + RuleComparisonField + "\">" + RuleMessage + " </li>";
                        }
                    }
                }

                // udpate wrapping markup
                if (e.FormComponent is DropDownComponent) {
                    //e.Configuration.ComponentWrapperConfiguration.HtmlAttributes["class"] = "select-wrapper";
                    e.Configuration.EditorHtmlAttributes["class"] = "custom-select";
                }
                else { e.Configuration.ComponentWrapperConfiguration.ElementName = ""; }

                // add class for type of validation
                e.Configuration.EditorHtmlAttributes["class"] += " zag-validation-input-text";

                // add a data-attribute that helps with matching validation rules such as two email fields needing to be identical
                e.Configuration.EditorHtmlAttributes["data-guid"] = e.FormComponent.BaseProperties.Guid.ToString();

                // aria attributes to tie form editor to it's error messages and write component to the page
                string ComponentGuid = e.FormComponent.BaseProperties.Guid.ToString().Replace("-", "_");

                if (e.FormComponent is Html5InputComponent)
                {
                    e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\">{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></div>").ToString();
                }
                else {
                    e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\">{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></div>").ToString();
                }

            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // RADIO BUTTONS
            //////////////////////////////////////////////////////////////////////////////////////////////
            else if (e.FormComponent is RadioButtonsComponent)
            {
                string ComponentClasses = "form-group form-group-radio";
                string ComponentErrors = "";

                if (e.FormComponent.BaseProperties.Required)
                {
                    ComponentClasses += " form-group--required";
                    ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"required\">" + e.FormComponent.BaseProperties.Label + " is a required field</li>";
                }

                // udpate wrapping markup
                e.Configuration.LabelWrapperConfiguration.ElementName = "legend";
                e.Configuration.LabelWrapperConfiguration.HtmlAttributes["class"] = "form-label";
                e.Configuration.LabelHtmlAttributes["role"] = "none";
                e.Configuration.EditorHtmlAttributes["class"] = "custom-control-input";

                // add class for type of validation
                e.Configuration.EditorHtmlAttributes["class"] += " zag-validation-input-radio";

                // add a data-attribute that helps with matching validation rules such as two email fields needing to be identical
                e.Configuration.EditorHtmlAttributes["data-guid"] = e.FormComponent.BaseProperties.Guid.ToString();

                // aria attributes to tie form editor to it's error messages and write component to the page
                string ComponentGuid = e.FormComponent.BaseProperties.Guid.ToString().Replace("-", "_");
                e.Configuration.EditorHtmlAttributes["aria-describedby"] = "Error_" + ComponentGuid;
                e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\"><fieldset>{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></fieldset></div>").ToString();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // MULTIPLE CHOICE
            //////////////////////////////////////////////////////////////////////////////////////////////
            else if (e.FormComponent is MultipleChoiceComponent)
            {
                string ComponentClasses = "form-group form-group-checkboxes";
                string ComponentErrors = "";

                if (e.FormComponent.BaseProperties.Required)
                {
                    ComponentClasses += " form-group--required";
                    ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"required\">" + e.FormComponent.BaseProperties.Label + " is a required field</li>";
                }

                // udpate wrapping markup
                e.Configuration.LabelWrapperConfiguration.ElementName = "legend";
                //e.Configuration.LabelHtmlAttributes["role"] = "none";

                // add class for type of validation
                e.Configuration.EditorHtmlAttributes["class"] += " zag-validation-input-checkboxes";

                // add a data-attribute that helps with matching validation rules such as two email fields needing to be identical
                e.Configuration.EditorHtmlAttributes["data-guid"] = e.FormComponent.BaseProperties.Guid.ToString();

                // aria attributes to tie form editor to it's error messages and write component to the page
                string ComponentGuid = e.FormComponent.BaseProperties.Guid.ToString().Replace("-", "_");
                e.Configuration.EditorHtmlAttributes["aria-describedby"] = "Error_" + ComponentGuid;
                e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\"><fieldset>{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></fieldset></div>").ToString();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // SINGLE CHECKBOX
            //////////////////////////////////////////////////////////////////////////////////////////////
            else if (e.FormComponent is CheckBoxComponent)
            {
                string ComponentClasses = "form-group form-group-checkbox";
                string ComponentErrors = "";

                // note kentico doesn't offer single checkbox as "required"
                // but kentico offers "component is enabled" validation rule
                // begin kentico validation rules
                if (e.FormComponent.BaseProperties.ValidationRuleConfigurations.Count > 0)
                {
                    foreach (var Rule in e.FormComponent.BaseProperties.ValidationRuleConfigurations)
                    {
                        if (Rule.Identifier == "Kentico.BoolIsSet")
                        {
                            var validationrule = Rule.ValidationRule as BoolIsSetValidationRule;
                            string RuleType = "boolisset";
                            string RuleMessage = validationrule.ErrorMessage;
                            ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"" + RuleType + "\">" + RuleMessage + " </li>";
                        }
                    }
                }

                // udpate wrapping markup
                e.Configuration.LabelWrapperConfiguration.ElementName = "span";
                e.Configuration.LabelHtmlAttributes["role"] = "none";
                e.Configuration.EditorHtmlAttributes["class"] = "custom-control-input";

                // add class for type of validation
                e.Configuration.EditorHtmlAttributes["class"] += " zag-validation-input-checkbox";

                // add a data-attribute that helps with matching validation rules such as two email fields needing to be identical
                e.Configuration.EditorHtmlAttributes["data-guid"] = e.FormComponent.BaseProperties.Guid.ToString();

                // aria attributes to tie form editor to it's error messages and write component to the page
                string ComponentGuid = e.FormComponent.BaseProperties.Guid.ToString().Replace("-", "_");
                e.Configuration.EditorHtmlAttributes["aria-describedby"] = "Error_" + ComponentGuid;
                e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\"><fieldset>{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></fieldset></div>").ToString();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // FILE UPLOADER
            //////////////////////////////////////////////////////////////////////////////////////////////
            else if (e.FormComponent is FileUploaderComponent)
            {
                string ComponentClasses = "form-group form-group-file";
                string ComponentErrors = "";

                if (e.FormComponent.BaseProperties.Required)
                {
                    ComponentClasses += " form-group-required";
                    ComponentErrors += "<li class=\"zag-validation-error\" data-ruletype=\"required\">" + e.FormComponent.BaseProperties.Label + " is a required field</li>";
                }

                // udpate wrapping markup
                e.Configuration.ComponentWrapperConfiguration.ElementName = "";
                e.Configuration.LabelWrapperConfiguration.ElementName = "legend";
                //e.Configuration.LabelHtmlAttributes["role"] = "none";

                // add class for type of validation
                e.Configuration.EditorHtmlAttributes["class"] += " zag-validation-input-file";

                // add a data-attribute that helps with matching validation rules such as two email fields needing to be identical
                e.Configuration.EditorHtmlAttributes["data-guid"] = e.FormComponent.BaseProperties.Guid.ToString();

                // aria attributes to tie form editor to it's error messages and write component to the page
                string ComponentGuid = e.FormComponent.BaseProperties.Guid.ToString().Replace("-", "_");
                e.Configuration.EditorHtmlAttributes["aria-describedby"] = "Error_" + ComponentGuid;
                e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\">{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></div>").ToString();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            // RECPATCHA
            //////////////////////////////////////////////////////////////////////////////////////////////
            else if (e.FormComponent is RecaptchaComponent)
            {
                string ComponentClasses = "form-group form-group-recaptcha form-group-required";
                string ComponentErrors = "<li class=\"zag-validation-error\" data-ruletype=\"recaptcha\">" + e.FormComponent.BaseProperties.Label + " is a required field</li>";

                // udpate wrapping markup
                e.Configuration.ComponentWrapperConfiguration.ElementName = "";

                // add class for type of validation
                e.Configuration.EditorHtmlAttributes["class"] += " zag-validation-input-recaptcha";

                // add a data-attribute that helps with matching validation rules such as two email fields needing to be identical
                e.Configuration.EditorHtmlAttributes["data-guid"] = e.FormComponent.BaseProperties.Guid.ToString();

                // aria attributes to tie form editor to it's error messages and write component to the page
                string ComponentGuid = e.FormComponent.BaseProperties.Guid.ToString().Replace("-", "_");
                e.Configuration.RootConfiguration.CustomHtmlString = new HtmlString($"<div class=\"{ComponentClasses}\">{ElementRenderingConfiguration.CONTENT_PLACEHOLDER}<ul id=\"Error_{ComponentGuid}\" class=\"zag-validation-errors\">{ComponentErrors}</ul></div>").ToString();
            }

        }

        private static void AddFormSpecificMarkup(GetFormFieldRenderingConfigurationEventArgs e)
        {
            // Gets the context of the Form for which the field is being rendered
            //BizFormComponentContext context = e.FormComponent.GetBizFormComponentContext();

            // Modifies only form fields rendered as part of the 'ContactUs' form
            //if (context.FormInfo.FormName.Equals("ContactUs", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    e.Configuration.ColonAfterLabel = false;
            //    e.Configuration.EditorHtmlAttributes["data-formname"] = context.FormInfo.FormDisplayName;
            //}
        }
    }

    public static class Extensions
    {
        public static string ReplaceCtrl(this string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                var isCtrl = char.IsControl(c);
                var n = char.ConvertToUtf32(s, i);

                if (isCtrl)
                {
                    sb.Append($"\\u{n:X4}");
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}