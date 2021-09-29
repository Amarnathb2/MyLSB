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

[assembly: RegisterDocumentType(PageBase.CLASS_NAME, typeof(PageBase))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type PageBase.
	/// </summary>
	public partial class PageBase : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.PageBase";


		/// <summary>
		/// The instance of the class that provides extended API for working with PageBase fields.
		/// </summary>
		private readonly PageBaseFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PageBaseID.
		/// </summary>
		[DatabaseIDField]
		public int PageBaseID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("PageBaseID"), 0);
			}
			set
			{
				SetValue("PageBaseID", value);
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
		/// Show insurance disclosure.
		/// </summary>
		[DatabaseField]
		public bool ShowInsuranceDisclosure
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("ShowInsuranceDisclosure"), false);
			}
			set
			{
				SetValue("ShowInsuranceDisclosure", value);
			}
		}


		/// <summary>
		/// Show footer emblems.
		/// </summary>
		[DatabaseField]
		public bool ShowFooterEmblems
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("ShowFooterEmblems"), true);
			}
			set
			{
				SetValue("ShowFooterEmblems", value);
			}
		}


		/// <summary>
		/// JSON.
		/// </summary>
		[DatabaseField]
		public string Schema
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Schema"), @"");
			}
			set
			{
				SetValue("Schema", value);
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
		/// Gets an object that provides extended API for working with PageBase fields.
		/// </summary>
		[RegisterProperty]
		public PageBaseFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with PageBase fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class PageBaseFields : AbstractHierarchicalObject<PageBaseFields>
		{
			/// <summary>
			/// The content item of type PageBase that is a target of the extended API.
			/// </summary>
			private readonly PageBase mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="PageBaseFields" /> class with the specified content item of type PageBase.
			/// </summary>
			/// <param name="instance">The content item of type PageBase that is a target of the extended API.</param>
			public PageBaseFields(PageBase instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PageBaseID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.PageBaseID;
				}
				set
				{
					mInstance.PageBaseID = value;
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
			/// Show insurance disclosure.
			/// </summary>
			public bool ShowInsuranceDisclosure
			{
				get
				{
					return mInstance.ShowInsuranceDisclosure;
				}
				set
				{
					mInstance.ShowInsuranceDisclosure = value;
				}
			}


			/// <summary>
			/// Show footer emblems.
			/// </summary>
			public bool ShowFooterEmblems
			{
				get
				{
					return mInstance.ShowFooterEmblems;
				}
				set
				{
					mInstance.ShowFooterEmblems = value;
				}
			}


			/// <summary>
			/// JSON.
			/// </summary>
			public string Schema
			{
				get
				{
					return mInstance.Schema;
				}
				set
				{
					mInstance.Schema = value;
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
		/// Initializes a new instance of the <see cref="PageBase" /> class.
		/// </summary>
		public PageBase() : base(CLASS_NAME)
		{
			mFields = new PageBaseFields(this);
		}

		#endregion
	}
}