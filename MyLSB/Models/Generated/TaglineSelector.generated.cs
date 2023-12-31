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

[assembly: RegisterDocumentType(TaglineSelector.CLASS_NAME, typeof(TaglineSelector))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type TaglineSelector.
	/// </summary>
	public partial class TaglineSelector : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.TaglineSelector";


		/// <summary>
		/// The instance of the class that provides extended API for working with TaglineSelector fields.
		/// </summary>
		private readonly TaglineSelectorFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// CrossPromoSelectorID.
		/// </summary>
		[DatabaseIDField]
		public int TaglineSelectorID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("TaglineSelectorID"), 0);
			}
			set
			{
				SetValue("TaglineSelectorID", value);
			}
		}


		/// <summary>
		/// TaglineSelectorName.
		/// </summary>
		[DatabaseField]
		public string TaglineSelectorName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TaglineSelectorName"), @"Tagline");
			}
			set
			{
				SetValue("TaglineSelectorName", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with TaglineSelector fields.
		/// </summary>
		[RegisterProperty]
		public TaglineSelectorFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with TaglineSelector fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class TaglineSelectorFields : AbstractHierarchicalObject<TaglineSelectorFields>
		{
			/// <summary>
			/// The content item of type TaglineSelector that is a target of the extended API.
			/// </summary>
			private readonly TaglineSelector mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="TaglineSelectorFields" /> class with the specified content item of type TaglineSelector.
			/// </summary>
			/// <param name="instance">The content item of type TaglineSelector that is a target of the extended API.</param>
			public TaglineSelectorFields(TaglineSelector instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// CrossPromoSelectorID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.TaglineSelectorID;
				}
				set
				{
					mInstance.TaglineSelectorID = value;
				}
			}


			/// <summary>
			/// TaglineSelectorName.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.TaglineSelectorName;
				}
				set
				{
					mInstance.TaglineSelectorName = value;
				}
			}


			/// <summary>
			/// Selected tagline.
			/// </summary>
			public IEnumerable<TreeNode> Tagline
			{
				get
				{
					return mInstance.GetRelatedDocuments("TaglineSelectorTagline");
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="TaglineSelector" /> class.
		/// </summary>
		public TaglineSelector() : base(CLASS_NAME)
		{
			mFields = new TaglineSelectorFields(this);
		}

		#endregion
	}
}