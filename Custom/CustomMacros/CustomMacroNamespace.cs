using CMS.Base;
using CMS.MacroEngine;

namespace Custom.CustomMacros
{
    [Extension(typeof(CustomMacroMethods))]
    public class CustomMacro : MacroNamespace<CustomMacro>
    {
    }
}
