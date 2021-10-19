using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    public class LocationsConfig 
    {

        public string GoogleClientGeoCodeUrl { get; set; }
        public string GoogleClientGeoCodeApiKey { get; set; }
        public string GoogleLocationGeoCodeUrl { get; set; }
        public string GoogleLocationDirectionsUrl { get; set; }
        public List<Connector> Connectors { get; set; }


        public static IConfigurationRoot GetConfigFile()
        {
            string applicationExeDirectory = ApplicationExeDirectory();

            var builder = new ConfigurationBuilder()
            .SetBasePath(applicationExeDirectory)
            .AddJsonFile("LocationsConfig.json");

            return builder.Build();
        }

        private static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);

            return appRoot;
        }

        public static LocationsConfig GetConfig()
        {
            LocationsConfig locationsConfig = GetConfigFile().GetSection("LocationsConfig").Get<LocationsConfig>();
            return locationsConfig;
        }
    }
}