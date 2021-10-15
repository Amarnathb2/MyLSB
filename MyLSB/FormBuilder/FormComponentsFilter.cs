using Kentico.Forms.Web.Mvc;
using Kentico.Forms.Web.Mvc.FormComponents;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.FormBuilder.FormBuilderCustomizations
{
    public class FormComponentsFilter : IFormComponentFilter
    {
        public IEnumerable<FormComponentDefinition> Filter(IEnumerable<FormComponentDefinition> formComponents, FormComponentFilterContext context)
        {
            // Filters specified form components
            return formComponents.Where(component => !GetComponentsToFilter().Contains(component.Identifier));
        }

        // A collection of form component identifiers to filter
        private IEnumerable<string> GetComponentsToFilter()
        {
            return new string[] {
                TextInputComponent.IDENTIFIER,
                IntInputComponent.IDENTIFIER,
                EmailInputComponent.IDENTIFIER,
                USPhoneComponent.IDENTIFIER
            };
        }
    }
}