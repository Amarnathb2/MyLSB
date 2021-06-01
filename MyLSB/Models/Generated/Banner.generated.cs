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

[assembly: RegisterDocumentType(Banner.CLASS_NAME, typeof(Banner))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type Banner.
	/// </summary>
	public partial class Banner : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.Banner";


		/// <summary>
		/// The instance of the class that provides extended API for working with Banner fields.
		/// </summary>
		private readonly BannerFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// MastheadID.
		/// </summary>
		[DatabaseIDField]
		public int BannerID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("BannerID"), 0);
			}
			set
			{
				SetValue("BannerID", value);
			}
		}


		/// <summary>
		/// BannerName.
		/// </summary>
		[DatabaseField]
		public string BannerName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerName"), @"Banner");
			}
			set
			{
				SetValue("BannerName", value);
			}
		}


		/// <summary>
		/// Heading.
		/// </summary>
		[DatabaseField]
		public string BannerHeading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerHeading"), @"");
			}
			set
			{
				SetValue("BannerHeading", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string BannerText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerText"), @"");
			}
			set
			{
				SetValue("BannerText", value);
			}
		}


		/// <summary>
		/// Image.
		/// </summary>
		[DatabaseField]
		public string BannerImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerImage"), @"");
			}
			set
			{
				SetValue("BannerImage", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string BannerButtonText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerButtonText"), @"");
			}
			set
			{
				SetValue("BannerButtonText", value);
			}
		}


		/// <summary>
		/// URL.
		/// </summary>
		[DatabaseField]
		public string BannerButtonUrl
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerButtonUrl"), @"");
			}
			set
			{
				SetValue("BannerButtonUrl", value);
			}
		}


		/// <summary>
		/// Open in a new tab.
		/// </summary>
		[DatabaseField]
		public bool BannerButtonNewTab
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("BannerButtonNewTab"), false);
			}
			set
			{
				SetValue("BannerButtonNewTab", value);
			}
		}


		/// <summary>
		/// Aria-label.
		/// </summary>
		[DatabaseField]
		public string BannerButtonAriaLabel
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerButtonAriaLabel"), @"");
			}
			set
			{
				SetValue("BannerButtonAriaLabel", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Banner fields.
		/// </summary>
		[RegisterProperty]
		public BannerFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Banner fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class BannerFields : AbstractHierarchicalObject<BannerFields>
		{
			/// <summary>
			/// The content item of type Banner that is a target of the extended API.
			/// </summary>
			private readonly Banner mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="BannerFields" /> class with the specified content item of type Banner.
			/// </summary>
			/// <param name="instance">The content item of type Banner that is a target of the extended API.</param>
			public BannerFields(Banner instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// MastheadID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.BannerID;
				}
				set
				{
					mInstance.BannerID = value;
				}
			}


			/// <summary>
			/// BannerName.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.BannerName;
				}
				set
				{
					mInstance.BannerName = value;
				}
			}


			/// <summary>
			/// Heading.
			/// </summary>
			public string Heading
			{
				get
				{
					return mInstance.BannerHeading;
				}
				set
				{
					mInstance.BannerHeading = value;
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string Text
			{
				get
				{
					return mInstance.BannerText;
				}
				set
				{
					mInstance.BannerText = value;
				}
			}


			/// <summary>
			/// Image.
			/// </summary>
			public string Image
			{
				get
				{
					return mInstance.BannerImage;
				}
				set
				{
					mInstance.BannerImage = value;
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string ButtonText
			{
				get
				{
					return mInstance.BannerButtonText;
				}
				set
				{
					mInstance.BannerButtonText = value;
				}
			}


			/// <summary>
			/// URL.
			/// </summary>
			public string ButtonUrl
			{
				get
				{
					return mInstance.BannerButtonUrl;
				}
				set
				{
					mInstance.BannerButtonUrl = value;
				}
			}


			/// <summary>
			/// Open in a new tab.
			/// </summary>
			public bool ButtonNewTab
			{
				get
				{
					return mInstance.BannerButtonNewTab;
				}
				set
				{
					mInstance.BannerButtonNewTab = value;
				}
			}


			/// <summary>
			/// Aria-label.
			/// </summary>
			public string ButtonAriaLabel
			{
				get
				{
					return mInstance.BannerButtonAriaLabel;
				}
				set
				{
					mInstance.BannerButtonAriaLabel = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Banner" /> class.
		/// </summary>
		public Banner() : base(CLASS_NAME)
		{
			mFields = new BannerFields(this);
		}

		#endregion
	}
}