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

[assembly: RegisterDocumentType(CrossPromo.CLASS_NAME, typeof(CrossPromo))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type CrossPromo.
	/// </summary>
	public partial class CrossPromo : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.CrossPromo";


		/// <summary>
		/// The instance of the class that provides extended API for working with CrossPromo fields.
		/// </summary>
		private readonly CrossPromoFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// CrossPromoID.
		/// </summary>
		[DatabaseIDField]
		public int CrossPromoID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CrossPromoID"), 0);
			}
			set
			{
				SetValue("CrossPromoID", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string CrossPromoName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CrossPromoName"), @"");
			}
			set
			{
				SetValue("CrossPromoName", value);
			}
		}


		/// <summary>
		/// Subtext.
		/// </summary>
		[DatabaseField]
		public string CrossPromoSubtext
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CrossPromoSubtext"), @"");
			}
			set
			{
				SetValue("CrossPromoSubtext", value);
			}
		}


		/// <summary>
		/// Image.
		/// </summary>
		[DatabaseField]
		public string CrossPromoImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CrossPromoImage"), @"");
			}
			set
			{
				SetValue("CrossPromoImage", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string CrossPromoButtonText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CrossPromoButtonText"), @"");
			}
			set
			{
				SetValue("CrossPromoButtonText", value);
			}
		}


		/// <summary>
		/// URL.
		/// </summary>
		[DatabaseField]
		public string CrossPromoButtonUrl
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CrossPromoButtonUrl"), @"");
			}
			set
			{
				SetValue("CrossPromoButtonUrl", value);
			}
		}


		/// <summary>
		/// Open in a new tab.
		/// </summary>
		[DatabaseField]
		public bool CrossPromoButtonNewTab
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("CrossPromoButtonNewTab"), false);
			}
			set
			{
				SetValue("CrossPromoButtonNewTab", value);
			}
		}


		/// <summary>
		/// Aria-label.
		/// </summary>
		[DatabaseField]
		public string CrossPromoButtonAriaLabel
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CrossPromoButtonAriaLabel"), @"");
			}
			set
			{
				SetValue("CrossPromoButtonAriaLabel", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with CrossPromo fields.
		/// </summary>
		[RegisterProperty]
		public CrossPromoFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CrossPromo fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CrossPromoFields : AbstractHierarchicalObject<CrossPromoFields>
		{
			/// <summary>
			/// The content item of type CrossPromo that is a target of the extended API.
			/// </summary>
			private readonly CrossPromo mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CrossPromoFields" /> class with the specified content item of type CrossPromo.
			/// </summary>
			/// <param name="instance">The content item of type CrossPromo that is a target of the extended API.</param>
			public CrossPromoFields(CrossPromo instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// CrossPromoID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CrossPromoID;
				}
				set
				{
					mInstance.CrossPromoID = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.CrossPromoName;
				}
				set
				{
					mInstance.CrossPromoName = value;
				}
			}


			/// <summary>
			/// Subtext.
			/// </summary>
			public string Subtext
			{
				get
				{
					return mInstance.CrossPromoSubtext;
				}
				set
				{
					mInstance.CrossPromoSubtext = value;
				}
			}


			/// <summary>
			/// Image.
			/// </summary>
			public string Image
			{
				get
				{
					return mInstance.CrossPromoImage;
				}
				set
				{
					mInstance.CrossPromoImage = value;
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string ButtonText
			{
				get
				{
					return mInstance.CrossPromoButtonText;
				}
				set
				{
					mInstance.CrossPromoButtonText = value;
				}
			}


			/// <summary>
			/// URL.
			/// </summary>
			public string ButtonUrl
			{
				get
				{
					return mInstance.CrossPromoButtonUrl;
				}
				set
				{
					mInstance.CrossPromoButtonUrl = value;
				}
			}


			/// <summary>
			/// Open in a new tab.
			/// </summary>
			public bool ButtonNewTab
			{
				get
				{
					return mInstance.CrossPromoButtonNewTab;
				}
				set
				{
					mInstance.CrossPromoButtonNewTab = value;
				}
			}


			/// <summary>
			/// Aria-label.
			/// </summary>
			public string ButtonAriaLabel
			{
				get
				{
					return mInstance.CrossPromoButtonAriaLabel;
				}
				set
				{
					mInstance.CrossPromoButtonAriaLabel = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="CrossPromo" /> class.
		/// </summary>
		public CrossPromo() : base(CLASS_NAME)
		{
			mFields = new CrossPromoFields(this);
		}

		#endregion
	}
}