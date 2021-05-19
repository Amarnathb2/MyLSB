using CMS;
using CMS.DataEngine;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(MyLSB.Modules.Locations.LocationsModule))]
namespace MyLSB.Modules.Locations
{
    public class LocationsModule : Module
    {
        // Module class constructor, the system registers the module under the name "LocationsAPI"
        public LocationsModule()
        : base("LocationsModule")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();
        }
    }
}