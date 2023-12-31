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

[assembly: RegisterDocumentType(BlogPostLink.CLASS_NAME, typeof(BlogPostLink))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type BlogPostLink.
	/// </summary>
	public partial class BlogPostLink : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.BlogPostLink";


		/// <summary>
		/// The instance of the class that provides extended API for working with BlogPostLink fields.
		/// </summary>
		private readonly BlogPostLinkFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// LinkID.
		/// </summary>
		[DatabaseIDField]
		public int BlogPostLinkID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("BlogPostLinkID"), 0);
			}
			set
			{
				SetValue("BlogPostLinkID", value);
			}
		}


		/// <summary>
		/// Post title.
		/// </summary>
		[DatabaseField]
		public string BlogPostLinkText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BlogPostLinkText"), @"");
			}
			set
			{
				SetValue("BlogPostLinkText", value);
			}
		}


		/// <summary>
		/// Post category.
		/// </summary>
		[DatabaseField]
		public string BlogPostLinkPostCategory
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BlogPostLinkPostCategory"), @"");
			}
			set
			{
				SetValue("BlogPostLinkPostCategory", value);
			}
		}


		/// <summary>
		/// URL.
		/// </summary>
		[DatabaseField]
		public string BlogPostLinkUrl
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BlogPostLinkUrl"), @"");
			}
			set
			{
				SetValue("BlogPostLinkUrl", value);
			}
		}


		/// <summary>
		/// Open in a new tab.
		/// </summary>
		[DatabaseField]
		public bool BlogPostLinkNewTab
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("BlogPostLinkNewTab"), true);
			}
			set
			{
				SetValue("BlogPostLinkNewTab", value);
			}
		}


		/// <summary>
		/// Aria-label.
		/// </summary>
		[DatabaseField]
		public string BlogPostLinkAriaLabel
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BlogPostLinkAriaLabel"), @"");
			}
			set
			{
				SetValue("BlogPostLinkAriaLabel", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with BlogPostLink fields.
		/// </summary>
		[RegisterProperty]
		public BlogPostLinkFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with BlogPostLink fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class BlogPostLinkFields : AbstractHierarchicalObject<BlogPostLinkFields>
		{
			/// <summary>
			/// The content item of type BlogPostLink that is a target of the extended API.
			/// </summary>
			private readonly BlogPostLink mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="BlogPostLinkFields" /> class with the specified content item of type BlogPostLink.
			/// </summary>
			/// <param name="instance">The content item of type BlogPostLink that is a target of the extended API.</param>
			public BlogPostLinkFields(BlogPostLink instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// LinkID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.BlogPostLinkID;
				}
				set
				{
					mInstance.BlogPostLinkID = value;
				}
			}


			/// <summary>
			/// Post title.
			/// </summary>
			public string Text
			{
				get
				{
					return mInstance.BlogPostLinkText;
				}
				set
				{
					mInstance.BlogPostLinkText = value;
				}
			}


			/// <summary>
			/// Post category.
			/// </summary>
			public string PostCategory
			{
				get
				{
					return mInstance.BlogPostLinkPostCategory;
				}
				set
				{
					mInstance.BlogPostLinkPostCategory = value;
				}
			}


			/// <summary>
			/// URL.
			/// </summary>
			public string Url
			{
				get
				{
					return mInstance.BlogPostLinkUrl;
				}
				set
				{
					mInstance.BlogPostLinkUrl = value;
				}
			}


			/// <summary>
			/// Open in a new tab.
			/// </summary>
			public bool NewTab
			{
				get
				{
					return mInstance.BlogPostLinkNewTab;
				}
				set
				{
					mInstance.BlogPostLinkNewTab = value;
				}
			}


			/// <summary>
			/// Aria-label.
			/// </summary>
			public string AriaLabel
			{
				get
				{
					return mInstance.BlogPostLinkAriaLabel;
				}
				set
				{
					mInstance.BlogPostLinkAriaLabel = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="BlogPostLink" /> class.
		/// </summary>
		public BlogPostLink() : base(CLASS_NAME)
		{
			mFields = new BlogPostLinkFields(this);
		}

		#endregion
	}
}