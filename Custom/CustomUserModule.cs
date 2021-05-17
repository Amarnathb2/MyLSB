using CMS;
using CMS.DataEngine;
using CMS.Membership;
using CMS.SiteProvider;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(Custom.CustomUserModule))]

namespace Custom
{
    public class CustomUserModule : Module
    {
        // Module class constructor, the system registers the module under the name "CustomUsers"
        public CustomUserModule()
            : base("CustomUsers")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            // Assigns a handler to the Insert.After event of user objects
            UserInfo.TYPEINFO.Events.Insert.After += User_InsertAfterEventHandler;
        }

        // Handler method that runs when a new user object is created in the system
        private void User_InsertAfterEventHandler(object sender, ObjectEventArgs e)
        {
            if (e.Object != null)
            {
                // Gets an info object representing the new user
                UserInfo user = (UserInfo)e.Object;

                // Gets the "DefaultRole" role
                RoleInfo role = RoleInfo.Provider.Get("DefaultRole", SiteContext.CurrentSiteID);

                if (role != null)
                {
                    // Assigns the role to the user
                    UserInfoProvider.AddUserToRole(user.UserName, role.RoleName, SiteContext.CurrentSiteName);
                }
            }
        }
    }
}