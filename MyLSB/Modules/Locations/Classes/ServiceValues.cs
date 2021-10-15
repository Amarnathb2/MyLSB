
namespace MyLSB.Modules.Locations.Classes
{
    public enum ServiceType
    {
        Website,
        CoopSb,
        CoopAtm,
        MoneyPass,
        StartPoint,
        SharedBranch,
        KenticoATM,
        LocatorSearch
    }

    public class ServiceValues
    {
        public string url;
        public string key;
        public string affiliateId;
        public string username;
        public string password;
        public ServiceType serviceType;


        public ServiceValues(string url, string key, ServiceType serviceType)
        {
            this.url = url;
            this.key = key;
            this.serviceType = serviceType;
        }

        public ServiceValues(string url, string key, string affiliateId, ServiceType serviceType) 
            : this(url,key,serviceType)
        {
            this.affiliateId = affiliateId;
        }

        public ServiceValues(ServiceType serviceType, string url, string LocatorSearch_Username, string LocatorSearch_Password)
        {
            this.url = url;
            this.serviceType = serviceType;
            username = LocatorSearch_Username;
            password = LocatorSearch_Password;
        }
    }
}
