using CMS;
using CMS.DataEngine;
using CMS.MacroEngine;
using Custom.CustomMacros;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(CustomMacroModule))]
namespace Custom.CustomMacros
{
    public class CustomMacroModule : Module
    {
        // Module class constructor, the system registers the module under the name "CustomMacros"
        public CustomMacroModule()
            : base("CustomMacros")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            // Registers "CustomNamespace" into the macro engine
            MacroContext.GlobalResolver.SetNamedSourceData("CustomMacros", CustomMacro.Instance);

            // Registers "CustomNamespace" as an anonymous macro source
            MacroContext.GlobalResolver.AddAnonymousSourceData(CustomMacro.Instance);
        }
    }
}