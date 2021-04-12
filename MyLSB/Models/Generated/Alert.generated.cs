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

[assembly: RegisterDocumentType(Alert.CLASS_NAME, typeof(Alert))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type Alert.
	/// </summary>
	public partial class Alert : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.Alert";


		/// <summary>
		/// The instance of the class that provides extended API for working with Alert fields.
		/// </summary>
		private readonly AlertFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// AlertID.
		/// </summary>
		[DatabaseIDField]
		public int AlertID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("AlertID"), 0);
			}
			set
			{
				SetValue("AlertID", value);
			}
		}


		/// <summary>
		/// Style.
		/// </summary>
		[DatabaseField]
		public string AlertStyle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("AlertStyle"), @"Primary");
			}
			set
			{
				SetValue("AlertStyle", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string AlertTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("AlertTitle"), @"");
			}
			set
			{
				SetValue("AlertTitle", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string AlertText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("AlertText"), @"");
			}
			set
			{
				SetValue("AlertText", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Alert fields.
		/// </summary>
		[RegisterProperty]
		public AlertFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Alert fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class AlertFields : AbstractHierarchicalObject<AlertFields>
		{
			/// <summary>
			/// The content item of type Alert that is a target of the extended API.
			/// </summary>
			private readonly Alert mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="AlertFields" /> class with the specified content item of type Alert.
			/// </summary>
			/// <param name="instance">The content item of type Alert that is a target of the extended API.</param>
			public AlertFields(Alert instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// AlertID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.AlertID;
				}
				set
				{
					mInstance.AlertID = value;
				}
			}


			/// <summary>
			/// Style.
			/// </summary>
			public string Style
			{
				get
				{
					return mInstance.AlertStyle;
				}
				set
				{
					mInstance.AlertStyle = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.AlertTitle;
				}
				set
				{
					mInstance.AlertTitle = value;
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string Text
			{
				get
				{
					return mInstance.AlertText;
				}
				set
				{
					mInstance.AlertText = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Alert" /> class.
		/// </summary>
		public Alert() : base(CLASS_NAME)
		{
			mFields = new AlertFields(this);
		}

		#endregion
	}
}