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

[assembly: RegisterDocumentType(PromoBand.CLASS_NAME, typeof(PromoBand))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type PromoBand.
	/// </summary>
	public partial class PromoBand : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.PromoBand";


		/// <summary>
		/// The instance of the class that provides extended API for working with PromoBand fields.
		/// </summary>
		private readonly PromoBandFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PromoBandID.
		/// </summary>
		[DatabaseIDField]
		public int PromoBandID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("PromoBandID"), 0);
			}
			set
			{
				SetValue("PromoBandID", value);
			}
		}


		/// <summary>
		/// PromoBandName.
		/// </summary>
		[DatabaseField]
		public string PromoBandName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandName"), @"Promo/Positioning Band");
			}
			set
			{
				SetValue("PromoBandName", value);
			}
		}


		/// <summary>
		/// Heading.
		/// </summary>
		[DatabaseField]
		public string PromoBandHeading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandHeading"), @"");
			}
			set
			{
				SetValue("PromoBandHeading", value);
			}
		}


		/// <summary>
		/// Subtext.
		/// </summary>
		[DatabaseField]
		public string PromoBandSubtext
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandSubtext"), @"");
			}
			set
			{
				SetValue("PromoBandSubtext", value);
			}
		}


		/// <summary>
		/// Icon.
		/// </summary>
		[DatabaseField]
		public string PromoBandIcon
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandIcon"), @"");
			}
			set
			{
				SetValue("PromoBandIcon", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string PromoBandLinkText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandLinkText"), @"");
			}
			set
			{
				SetValue("PromoBandLinkText", value);
			}
		}


		/// <summary>
		/// URL.
		/// </summary>
		[DatabaseField]
		public string PromoBandLinkUrl
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandLinkUrl"), @"");
			}
			set
			{
				SetValue("PromoBandLinkUrl", value);
			}
		}


		/// <summary>
		/// Open in a new tab.
		/// </summary>
		[DatabaseField]
		public bool PromoBandLinkNewTab
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("PromoBandLinkNewTab"), false);
			}
			set
			{
				SetValue("PromoBandLinkNewTab", value);
			}
		}


		/// <summary>
		/// Aria-label.
		/// </summary>
		[DatabaseField]
		public string PromoBandLinkAriaLabel
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PromoBandLinkAriaLabel"), @"");
			}
			set
			{
				SetValue("PromoBandLinkAriaLabel", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with PromoBand fields.
		/// </summary>
		[RegisterProperty]
		public PromoBandFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with PromoBand fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class PromoBandFields : AbstractHierarchicalObject<PromoBandFields>
		{
			/// <summary>
			/// The content item of type PromoBand that is a target of the extended API.
			/// </summary>
			private readonly PromoBand mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="PromoBandFields" /> class with the specified content item of type PromoBand.
			/// </summary>
			/// <param name="instance">The content item of type PromoBand that is a target of the extended API.</param>
			public PromoBandFields(PromoBand instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PromoBandID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.PromoBandID;
				}
				set
				{
					mInstance.PromoBandID = value;
				}
			}


			/// <summary>
			/// PromoBandName.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.PromoBandName;
				}
				set
				{
					mInstance.PromoBandName = value;
				}
			}


			/// <summary>
			/// Heading.
			/// </summary>
			public string Heading
			{
				get
				{
					return mInstance.PromoBandHeading;
				}
				set
				{
					mInstance.PromoBandHeading = value;
				}
			}


			/// <summary>
			/// Subtext.
			/// </summary>
			public string Subtext
			{
				get
				{
					return mInstance.PromoBandSubtext;
				}
				set
				{
					mInstance.PromoBandSubtext = value;
				}
			}


			/// <summary>
			/// Icon.
			/// </summary>
			public string Icon
			{
				get
				{
					return mInstance.PromoBandIcon;
				}
				set
				{
					mInstance.PromoBandIcon = value;
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string LinkText
			{
				get
				{
					return mInstance.PromoBandLinkText;
				}
				set
				{
					mInstance.PromoBandLinkText = value;
				}
			}


			/// <summary>
			/// URL.
			/// </summary>
			public string LinkUrl
			{
				get
				{
					return mInstance.PromoBandLinkUrl;
				}
				set
				{
					mInstance.PromoBandLinkUrl = value;
				}
			}


			/// <summary>
			/// Open in a new tab.
			/// </summary>
			public bool LinkNewTab
			{
				get
				{
					return mInstance.PromoBandLinkNewTab;
				}
				set
				{
					mInstance.PromoBandLinkNewTab = value;
				}
			}


			/// <summary>
			/// Aria-label.
			/// </summary>
			public string LinkAriaLabel
			{
				get
				{
					return mInstance.PromoBandLinkAriaLabel;
				}
				set
				{
					mInstance.PromoBandLinkAriaLabel = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="PromoBand" /> class.
		/// </summary>
		public PromoBand() : base(CLASS_NAME)
		{
			mFields = new PromoBandFields(this);
		}

		#endregion
	}
}