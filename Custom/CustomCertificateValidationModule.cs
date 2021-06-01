using CMS;
using CMS.Core;
using CMS.DataEngine;
using System.Net;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(CustomCertificateValidationModule))]

public class CustomCertificateValidationModule : Module
{
    // Module class constructor, the system registers the module under the name "CustomCertificateValidation"
    public CustomCertificateValidationModule()
        : base("CustomCertificateValidation")
    {
    }

    // Contains initialization code that is executed when the application starts
    protected override void OnInit()
    {
        base.OnInit();

        if (bool.Parse(Service.Resolve<IAppSettingsService>()["CMSAllowAllCertificates"]))
        {
            ServicePointManager.ServerCertificateValidationCallback = (request, cert, chain, errors) => true;
        }

    }
}