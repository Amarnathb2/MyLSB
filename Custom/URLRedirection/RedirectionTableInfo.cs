using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using URLRedirection;

[assembly: RegisterObjectType(typeof(RedirectionTableInfo), RedirectionTableInfo.OBJECT_TYPE)]
    
namespace URLRedirection
{
    /// <summary>
    /// RedirectionTableInfo data container class.
    /// </summary>
	[Serializable]
    public class RedirectionTableInfo : AbstractInfo<RedirectionTableInfo>
    {
        #region "Type information"

        /// <summary>
        /// Object type
        /// </summary>
        public const string OBJECT_TYPE = "urlredirection.redirectiontable";


        /// <summary>
        /// Type information.
        /// </summary>
        public static ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(RedirectionTableInfoProvider), OBJECT_TYPE, "URLRedirection.RedirectionTable", "RedirectionTableID", null, null, null, null, null, "RedirectionSiteID", null, null)
        {
			ModuleName = "URLRedirection",
			TouchCacheDependencies = true,
            DependsOn = new List<ObjectDependency>() 
			{
			    new ObjectDependency("RedirectionSiteID", "cms.site", ObjectDependencyEnum.RequiredHasDefault), 
            },
        };

        #endregion


        #region "Properties"

        /// <summary>
        /// Redirection table ID
        /// </summary>
        [DatabaseField]
        public virtual int RedirectionTableID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("RedirectionTableID"), 0);
            }
            set
            {
                SetValue("RedirectionTableID", value);
            }
        }


        /// <summary>
        /// Redirection original URL
        /// </summary>
        [DatabaseField]
        public virtual string RedirectionOriginalURL
        {
            get
            {
                return ValidationHelper.GetString(GetValue("RedirectionOriginalURL"), String.Empty);
            }
            set
            {
                SetValue("RedirectionOriginalURL", value);
            }
        }


        /// <summary>
        /// Redirection target URL
        /// </summary>
        [DatabaseField]
        public virtual string RedirectionTargetURL
        {
            get
            {
                return ValidationHelper.GetString(GetValue("RedirectionTargetURL"), String.Empty);
            }
            set
            {
                SetValue("RedirectionTargetURL", value);
            }
        }


        /// <summary>
        /// Redirection site ID
        /// </summary>
        [DatabaseField]
        public virtual int RedirectionSiteID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("RedirectionSiteID"), 0);
            }
            set
            {
                SetValue("RedirectionSiteID", value);
            }
        }


        /// <summary>
        /// Redirection type
        /// </summary>
        [DatabaseField]
        public virtual string RedirectionType
        {
            get
            {
                return ValidationHelper.GetString(GetValue("RedirectionType"), String.Empty);
            }
            set
            {
                SetValue("RedirectionType", value);
            }
        }

        #endregion


        #region "Type based properties and methods"

        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            RedirectionTableInfoProvider.DeleteRedirectionTableInfo(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            RedirectionTableInfoProvider.SetRedirectionTableInfo(this);
        }

        #endregion


        #region "Constructors"

		/// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public RedirectionTableInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Constructor - Creates an empty RedirectionTableInfo object.
        /// </summary>
        public RedirectionTableInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Constructor - Creates a new RedirectionTableInfo object from the given DataRow.
        /// </summary>
        /// <param name="dr">DataRow with the object data</param>
        public RedirectionTableInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }

        #endregion
    }
}