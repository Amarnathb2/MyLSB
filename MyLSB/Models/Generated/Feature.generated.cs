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

[assembly: RegisterDocumentType(Feature.CLASS_NAME, typeof(Feature))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type Feature.
	/// </summary>
	public partial class Feature : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.Feature";


		/// <summary>
		/// The instance of the class that provides extended API for working with Feature fields.
		/// </summary>
		private readonly FeatureFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// FeatureID.
		/// </summary>
		[DatabaseIDField]
		public int FeatureID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("FeatureID"), 0);
			}
			set
			{
				SetValue("FeatureID", value);
			}
		}


		/// <summary>
		/// Show a rate .
		/// </summary>
		[DatabaseField]
		public bool FeatureIsRate
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("FeatureIsRate"), false);
			}
			set
			{
				SetValue("FeatureIsRate", value);
			}
		}


		/// <summary>
		/// Rate.
		/// </summary>
		[DatabaseField]
		public string FeatureRate
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeatureRate"), @"");
			}
			set
			{
				SetValue("FeatureRate", value);
			}
		}


		/// <summary>
		/// Rate label.
		/// </summary>
		[DatabaseField]
		public string FeatureRateLabel
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeatureRateLabel"), @"");
			}
			set
			{
				SetValue("FeatureRateLabel", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Feature fields.
		/// </summary>
		[RegisterProperty]
		public FeatureFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Feature fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class FeatureFields : AbstractHierarchicalObject<FeatureFields>
		{
			/// <summary>
			/// The content item of type Feature that is a target of the extended API.
			/// </summary>
			private readonly Feature mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="FeatureFields" /> class with the specified content item of type Feature.
			/// </summary>
			/// <param name="instance">The content item of type Feature that is a target of the extended API.</param>
			public FeatureFields(Feature instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// FeatureID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.FeatureID;
				}
				set
				{
					mInstance.FeatureID = value;
				}
			}


			/// <summary>
			/// Show a rate .
			/// </summary>
			public bool IsRate
			{
				get
				{
					return mInstance.FeatureIsRate;
				}
				set
				{
					mInstance.FeatureIsRate = value;
				}
			}


			/// <summary>
			/// Rate.
			/// </summary>
			public string Rate
			{
				get
				{
					return mInstance.FeatureRate;
				}
				set
				{
					mInstance.FeatureRate = value;
				}
			}


			/// <summary>
			/// Rate label.
			/// </summary>
			public string RateLabel
			{
				get
				{
					return mInstance.FeatureRateLabel;
				}
				set
				{
					mInstance.FeatureRateLabel = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Feature" /> class.
		/// </summary>
		public Feature() : base(CLASS_NAME)
		{
			mFields = new FeatureFields(this);
		}

		#endregion
	}
}