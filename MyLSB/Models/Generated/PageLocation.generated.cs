//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;

[assembly: RegisterDocumentType(PageLocation.CLASS_NAME, typeof(PageLocation))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type PageLocation.
	/// </summary>
	public partial class PageLocation : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.PageLocation";


		/// <summary>
		/// The instance of the class that provides extended API for working with PageLocation fields.
		/// </summary>
		private readonly PageLocationFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PageDefaultID.
		/// </summary>
		[DatabaseIDField]
		public int PageLocationID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("PageLocationID"), 0);
			}
			set
			{
				SetValue("PageLocationID", value);
			}
		}


		/// <summary>
		/// Location name.
		/// </summary>
		[DatabaseField]
		public string LocationTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationTitle"), @"");
			}
			set
			{
				SetValue("LocationTitle", value);
			}
		}


		/// <summary>
		/// Latitude.
		/// </summary>
		[DatabaseField]
		public string LocationLatitude
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationLatitude"), @"");
			}
			set
			{
				SetValue("LocationLatitude", value);
			}
		}


		/// <summary>
		/// Longitude.
		/// </summary>
		[DatabaseField]
		public string LocationLongitude
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationLongitude"), @"");
			}
			set
			{
				SetValue("LocationLongitude", value);
			}
		}


		/// <summary>
		/// Address.
		/// </summary>
		[DatabaseField]
		public string LocationAddress1
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationAddress1"), @"");
			}
			set
			{
				SetValue("LocationAddress1", value);
			}
		}


		/// <summary>
		/// Address 2.
		/// </summary>
		[DatabaseField]
		public string LocationAddress2
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationAddress2"), @"");
			}
			set
			{
				SetValue("LocationAddress2", value);
			}
		}


		/// <summary>
		/// City.
		/// </summary>
		[DatabaseField]
		public string LocationCity
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationCity"), @"");
			}
			set
			{
				SetValue("LocationCity", value);
			}
		}


		/// <summary>
		/// State.
		/// </summary>
		[DatabaseField]
		public string LocationState
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationState"), @"");
			}
			set
			{
				SetValue("LocationState", value);
			}
		}


		/// <summary>
		/// Zip Code.
		/// </summary>
		[DatabaseField]
		public string LocationZipCode
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationZipCode"), @"");
			}
			set
			{
				SetValue("LocationZipCode", value);
			}
		}


		/// <summary>
		/// Phone.
		/// </summary>
		[DatabaseField]
		public string LocationPhone
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationPhone"), @"");
			}
			set
			{
				SetValue("LocationPhone", value);
			}
		}


		/// <summary>
		/// Fax.
		/// </summary>
		[DatabaseField]
		public string LocationFax
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationFax"), @"");
			}
			set
			{
				SetValue("LocationFax", value);
			}
		}


		/// <summary>
		/// Hours of Operation.
		/// </summary>
		[DatabaseField]
		public string LocationHours
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationHours"), @"");
			}
			set
			{
				SetValue("LocationHours", value);
			}
		}


		/// <summary>
		/// Features.
		/// </summary>
		[DatabaseField]
		public string LocationFeatures
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LocationFeatures"), @"");
			}
			set
			{
				SetValue("LocationFeatures", value);
			}
		}


		/// <summary>
		/// Banking and Financial Services.
		/// </summary>
		[DatabaseField]
		public bool LocationTypeBankingFinancialServices
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("LocationTypeBankingFinancialServices"), false);
			}
			set
			{
				SetValue("LocationTypeBankingFinancialServices", value);
			}
		}


		/// <summary>
		/// Insurance, Trust and Wealth Management.
		/// </summary>
		[DatabaseField]
		public bool LocationTypeInsuranceTrustWealthManagement
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("LocationTypeInsuranceTrustWealthManagement"), false);
			}
			set
			{
				SetValue("LocationTypeInsuranceTrustWealthManagement", value);
			}
		}


		/// <summary>
		/// Hide from search engines (noindex).
		/// </summary>
		[DatabaseField]
		public bool NoIndex
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("NoIndex"), false);
			}
			set
			{
				SetValue("NoIndex", value);
			}
		}


		/// <summary>
		/// Show in site map.
		/// </summary>
		[DatabaseField]
		public bool ShowInSitemap
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("ShowInSitemap"), true);
			}
			set
			{
				SetValue("ShowInSitemap", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string OpenGraphTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("OpenGraphTitle"), @"");
			}
			set
			{
				SetValue("OpenGraphTitle", value);
			}
		}


		/// <summary>
		/// Type.
		/// </summary>
		[DatabaseField]
		public string OpenGraphType
		{
			get
			{
				return ValidationHelper.GetString(GetValue("OpenGraphType"), @"website");
			}
			set
			{
				SetValue("OpenGraphType", value);
			}
		}


		/// <summary>
		/// Image.
		/// </summary>
		[DatabaseField]
		public string OpenGraphImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("OpenGraphImage"), @"");
			}
			set
			{
				SetValue("OpenGraphImage", value);
			}
		}


		/// <summary>
		/// Image Alt text.
		/// </summary>
		[DatabaseField]
		public string OpenGraphImageAlt
		{
			get
			{
				return ValidationHelper.GetString(GetValue("OpenGraphImageAlt"), @"");
			}
			set
			{
				SetValue("OpenGraphImageAlt", value);
			}
		}


		/// <summary>
		/// Description.
		/// </summary>
		[DatabaseField]
		public string OpenGraphDescription
		{
			get
			{
				return ValidationHelper.GetString(GetValue("OpenGraphDescription"), @"");
			}
			set
			{
				SetValue("OpenGraphDescription", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with PageLocation fields.
		/// </summary>
		[RegisterProperty]
		public PageLocationFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with PageLocation fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class PageLocationFields : AbstractHierarchicalObject<PageLocationFields>
		{
			/// <summary>
			/// The content item of type PageLocation that is a target of the extended API.
			/// </summary>
			private readonly PageLocation mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="PageLocationFields" /> class with the specified content item of type PageLocation.
			/// </summary>
			/// <param name="instance">The content item of type PageLocation that is a target of the extended API.</param>
			public PageLocationFields(PageLocation instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PageDefaultID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.PageLocationID;
				}
				set
				{
					mInstance.PageLocationID = value;
				}
			}


			/// <summary>
			/// Location name.
			/// </summary>
			public string LocationTitle
			{
				get
				{
					return mInstance.LocationTitle;
				}
				set
				{
					mInstance.LocationTitle = value;
				}
			}


			/// <summary>
			/// Latitude.
			/// </summary>
			public string LocationLatitude
			{
				get
				{
					return mInstance.LocationLatitude;
				}
				set
				{
					mInstance.LocationLatitude = value;
				}
			}


			/// <summary>
			/// Longitude.
			/// </summary>
			public string LocationLongitude
			{
				get
				{
					return mInstance.LocationLongitude;
				}
				set
				{
					mInstance.LocationLongitude = value;
				}
			}


			/// <summary>
			/// Address.
			/// </summary>
			public string LocationAddress1
			{
				get
				{
					return mInstance.LocationAddress1;
				}
				set
				{
					mInstance.LocationAddress1 = value;
				}
			}


			/// <summary>
			/// Address 2.
			/// </summary>
			public string LocationAddress2
			{
				get
				{
					return mInstance.LocationAddress2;
				}
				set
				{
					mInstance.LocationAddress2 = value;
				}
			}


			/// <summary>
			/// City.
			/// </summary>
			public string LocationCity
			{
				get
				{
					return mInstance.LocationCity;
				}
				set
				{
					mInstance.LocationCity = value;
				}
			}


			/// <summary>
			/// State.
			/// </summary>
			public string LocationState
			{
				get
				{
					return mInstance.LocationState;
				}
				set
				{
					mInstance.LocationState = value;
				}
			}


			/// <summary>
			/// Zip Code.
			/// </summary>
			public string LocationZipCode
			{
				get
				{
					return mInstance.LocationZipCode;
				}
				set
				{
					mInstance.LocationZipCode = value;
				}
			}


			/// <summary>
			/// Phone.
			/// </summary>
			public string LocationPhone
			{
				get
				{
					return mInstance.LocationPhone;
				}
				set
				{
					mInstance.LocationPhone = value;
				}
			}


			/// <summary>
			/// Fax.
			/// </summary>
			public string LocationFax
			{
				get
				{
					return mInstance.LocationFax;
				}
				set
				{
					mInstance.LocationFax = value;
				}
			}


			/// <summary>
			/// Hours of Operation.
			/// </summary>
			public string LocationHours
			{
				get
				{
					return mInstance.LocationHours;
				}
				set
				{
					mInstance.LocationHours = value;
				}
			}


			/// <summary>
			/// Features.
			/// </summary>
			public string LocationFeatures
			{
				get
				{
					return mInstance.LocationFeatures;
				}
				set
				{
					mInstance.LocationFeatures = value;
				}
			}


			/// <summary>
			/// Banking and Financial Services.
			/// </summary>
			public bool LocationTypeBankingFinancialServices
			{
				get
				{
					return mInstance.LocationTypeBankingFinancialServices;
				}
				set
				{
					mInstance.LocationTypeBankingFinancialServices = value;
				}
			}


			/// <summary>
			/// Insurance, Trust and Wealth Management.
			/// </summary>
			public bool LocationTypeInsuranceTrustWealthManagement
			{
				get
				{
					return mInstance.LocationTypeInsuranceTrustWealthManagement;
				}
				set
				{
					mInstance.LocationTypeInsuranceTrustWealthManagement = value;
				}
			}


			/// <summary>
			/// Hide from search engines (noindex).
			/// </summary>
			public bool NoIndex
			{
				get
				{
					return mInstance.NoIndex;
				}
				set
				{
					mInstance.NoIndex = value;
				}
			}


			/// <summary>
			/// Show in site map.
			/// </summary>
			public bool ShowInSitemap
			{
				get
				{
					return mInstance.ShowInSitemap;
				}
				set
				{
					mInstance.ShowInSitemap = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string OpenGraphTitle
			{
				get
				{
					return mInstance.OpenGraphTitle;
				}
				set
				{
					mInstance.OpenGraphTitle = value;
				}
			}


			/// <summary>
			/// Type.
			/// </summary>
			public string OpenGraphType
			{
				get
				{
					return mInstance.OpenGraphType;
				}
				set
				{
					mInstance.OpenGraphType = value;
				}
			}


			/// <summary>
			/// Image.
			/// </summary>
			public string OpenGraphImage
			{
				get
				{
					return mInstance.OpenGraphImage;
				}
				set
				{
					mInstance.OpenGraphImage = value;
				}
			}


			/// <summary>
			/// Image Alt text.
			/// </summary>
			public string OpenGraphImageAlt
			{
				get
				{
					return mInstance.OpenGraphImageAlt;
				}
				set
				{
					mInstance.OpenGraphImageAlt = value;
				}
			}


			/// <summary>
			/// Description.
			/// </summary>
			public string OpenGraphDescription
			{
				get
				{
					return mInstance.OpenGraphDescription;
				}
				set
				{
					mInstance.OpenGraphDescription = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="PageLocation" /> class.
		/// </summary>
		public PageLocation() : base(CLASS_NAME)
		{
			mFields = new PageLocationFields(this);
		}

		#endregion
	}
}