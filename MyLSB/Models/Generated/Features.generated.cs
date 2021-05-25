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

[assembly: RegisterDocumentType(Features.CLASS_NAME, typeof(Features))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type Features.
	/// </summary>
	public partial class Features : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.Features";


		/// <summary>
		/// The instance of the class that provides extended API for working with Features fields.
		/// </summary>
		private readonly FeaturesFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// FeaturesID.
		/// </summary>
		[DatabaseIDField]
		public int FeaturesID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("FeaturesID"), 0);
			}
			set
			{
				SetValue("FeaturesID", value);
			}
		}


		/// <summary>
		/// FeaturesName.
		/// </summary>
		[DatabaseField]
		public string FeaturesName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturesName"), @"Features");
			}
			set
			{
				SetValue("FeaturesName", value);
			}
		}


		/// <summary>
		/// Heading.
		/// </summary>
		[DatabaseField]
		public string FeaturesHeading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturesHeading"), @"");
			}
			set
			{
				SetValue("FeaturesHeading", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Features fields.
		/// </summary>
		[RegisterProperty]
		public FeaturesFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Features fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class FeaturesFields : AbstractHierarchicalObject<FeaturesFields>
		{
			/// <summary>
			/// The content item of type Features that is a target of the extended API.
			/// </summary>
			private readonly Features mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="FeaturesFields" /> class with the specified content item of type Features.
			/// </summary>
			/// <param name="instance">The content item of type Features that is a target of the extended API.</param>
			public FeaturesFields(Features instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// FeaturesID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.FeaturesID;
				}
				set
				{
					mInstance.FeaturesID = value;
				}
			}


			/// <summary>
			/// FeaturesName.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.FeaturesName;
				}
				set
				{
					mInstance.FeaturesName = value;
				}
			}


			/// <summary>
			/// Heading.
			/// </summary>
			public string Heading
			{
				get
				{
					return mInstance.FeaturesHeading;
				}
				set
				{
					mInstance.FeaturesHeading = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Features" /> class.
		/// </summary>
		public Features() : base(CLASS_NAME)
		{
			mFields = new FeaturesFields(this);
		}

		#endregion
	}
}