using CMS.Base;
using CMS.MacroEngine;

namespace Custom
{
    [Extension(typeof(CustomMacroMethods))]
    public class CustomMacro : MacroNamespace<CustomMacro>
    {
    }
}
