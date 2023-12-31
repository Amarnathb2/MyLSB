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

[assembly: RegisterDocumentType(JsonTablePicker.CLASS_NAME, typeof(JsonTablePicker))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type JsonTablePicker.
	/// </summary>
	public partial class JsonTablePicker : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.JsonTablePicker";


		/// <summary>
		/// The instance of the class that provides extended API for working with JsonTablePicker fields.
		/// </summary>
		private readonly JsonTablePickerFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PartialRichTextID.
		/// </summary>
		[DatabaseIDField]
		public int JsonTablePickerID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("JsonTablePickerID"), 0);
			}
			set
			{
				SetValue("JsonTablePickerID", value);
			}
		}


		/// <summary>
		/// JsonTableName.
		/// </summary>
		[DatabaseField]
		public string JsonTableName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("JsonTableName"), @"Table");
			}
			set
			{
				SetValue("JsonTableName", value);
			}
		}


		/// <summary>
		/// Key.
		/// </summary>
		[DatabaseField]
		public string Key
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Key"), @"");
			}
			set
			{
				SetValue("Key", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Text.
		/// </summary>
		[DatabaseField]
		public string Text
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Text"), @"");
			}
			set
			{
				SetValue("Text", value);
			}
		}


		/// <summary>
		/// Table Picker.
		/// </summary>
		[DatabaseField]
		public string TablePicker
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TablePicker"), @"");
			}
			set
			{
				SetValue("TablePicker", value);
			}
		}


		/// <summary>
		/// Table display type.
		/// </summary>
		[DatabaseField]
		public string TableDisplayType
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TableDisplayType"), @"default");
			}
			set
			{
				SetValue("TableDisplayType", value);
			}
		}


		/// <summary>
		/// Should all additional table settings inherit from the selected table?.
		/// </summary>
		[DatabaseField]
		public string InheritAllSettings
		{
			get
			{
				return ValidationHelper.GetString(GetValue("InheritAllSettings"), @"No");
			}
			set
			{
				SetValue("InheritAllSettings", value);
			}
		}


		/// <summary>
		/// First column as heading.
		/// </summary>
		[DatabaseField]
		public bool TableFirstColumn
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("TableFirstColumn"), false);
			}
			set
			{
				SetValue("TableFirstColumn", value);
			}
		}


		/// <summary>
		/// Caption.
		/// </summary>
		[DatabaseField]
		public string TableCaption
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TableCaption"), @"");
			}
			set
			{
				SetValue("TableCaption", value);
			}
		}


		/// <summary>
		/// Additional Info.
		/// </summary>
		[DatabaseField]
		public string TableAdditionalInfo
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TableAdditionalInfo"), @"");
			}
			set
			{
				SetValue("TableAdditionalInfo", value);
			}
		}


		/// <summary>
		/// Button Text.
		/// </summary>
		[DatabaseField]
		public string TableButtonText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TableButtonText"), @"");
			}
			set
			{
				SetValue("TableButtonText", value);
			}
		}


		/// <summary>
		/// Button URL.
		/// </summary>
		[DatabaseField]
		public string TableButtonURL
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TableButtonURL"), @"");
			}
			set
			{
				SetValue("TableButtonURL", value);
			}
		}


		/// <summary>
		/// Open in a new tab?.
		/// </summary>
		[DatabaseField]
		public bool TableButtonNewTab
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("TableButtonNewTab"), false);
			}
			set
			{
				SetValue("TableButtonNewTab", value);
			}
		}


		/// <summary>
		/// Disclosures.
		/// </summary>
		[DatabaseField]
		public string TableDisclosures
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TableDisclosures"), @"");
			}
			set
			{
				SetValue("TableDisclosures", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with JsonTablePicker fields.
		/// </summary>
		[RegisterProperty]
		public JsonTablePickerFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with JsonTablePicker fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class JsonTablePickerFields : AbstractHierarchicalObject<JsonTablePickerFields>
		{
			/// <summary>
			/// The content item of type JsonTablePicker that is a target of the extended API.
			/// </summary>
			private readonly JsonTablePicker mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="JsonTablePickerFields" /> class with the specified content item of type JsonTablePicker.
			/// </summary>
			/// <param name="instance">The content item of type JsonTablePicker that is a target of the extended API.</param>
			public JsonTablePickerFields(JsonTablePicker instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PartialRichTextID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.JsonTablePickerID;
				}
				set
				{
					mInstance.JsonTablePickerID = value;
				}
			}


			/// <summary>
			/// JsonTableName.
			/// </summary>
			public string JsonTableName
			{
				get
				{
					return mInstance.JsonTableName;
				}
				set
				{
					mInstance.JsonTableName = value;
				}
			}


			/// <summary>
			/// Key.
			/// </summary>
			public string Key
			{
				get
				{
					return mInstance.Key;
				}
				set
				{
					mInstance.Key = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}


			/// <summary>
			/// Text.
			/// </summary>
			public string Text
			{
				get
				{
					return mInstance.Text;
				}
				set
				{
					mInstance.Text = value;
				}
			}


			/// <summary>
			/// Table Picker.
			/// </summary>
			public string TablePicker
			{
				get
				{
					return mInstance.TablePicker;
				}
				set
				{
					mInstance.TablePicker = value;
				}
			}


			/// <summary>
			/// Table display type.
			/// </summary>
			public string TableDisplayType
			{
				get
				{
					return mInstance.TableDisplayType;
				}
				set
				{
					mInstance.TableDisplayType = value;
				}
			}


			/// <summary>
			/// Should all additional table settings inherit from the selected table?.
			/// </summary>
			public string InheritAllSettings
			{
				get
				{
					return mInstance.InheritAllSettings;
				}
				set
				{
					mInstance.InheritAllSettings = value;
				}
			}


			/// <summary>
			/// First column as heading.
			/// </summary>
			public bool TableFirstColumn
			{
				get
				{
					return mInstance.TableFirstColumn;
				}
				set
				{
					mInstance.TableFirstColumn = value;
				}
			}


			/// <summary>
			/// Caption.
			/// </summary>
			public string TableCaption
			{
				get
				{
					return mInstance.TableCaption;
				}
				set
				{
					mInstance.TableCaption = value;
				}
			}


			/// <summary>
			/// Additional Info.
			/// </summary>
			public string TableAdditionalInfo
			{
				get
				{
					return mInstance.TableAdditionalInfo;
				}
				set
				{
					mInstance.TableAdditionalInfo = value;
				}
			}


			/// <summary>
			/// Button Text.
			/// </summary>
			public string TableButtonText
			{
				get
				{
					return mInstance.TableButtonText;
				}
				set
				{
					mInstance.TableButtonText = value;
				}
			}


			/// <summary>
			/// Button URL.
			/// </summary>
			public string TableButtonURL
			{
				get
				{
					return mInstance.TableButtonURL;
				}
				set
				{
					mInstance.TableButtonURL = value;
				}
			}


			/// <summary>
			/// Open in a new tab?.
			/// </summary>
			public bool TableButtonNewTab
			{
				get
				{
					return mInstance.TableButtonNewTab;
				}
				set
				{
					mInstance.TableButtonNewTab = value;
				}
			}


			/// <summary>
			/// Disclosures.
			/// </summary>
			public string TableDisclosures
			{
				get
				{
					return mInstance.TableDisclosures;
				}
				set
				{
					mInstance.TableDisclosures = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonTablePicker" /> class.
		/// </summary>
		public JsonTablePicker() : base(CLASS_NAME)
		{
			mFields = new JsonTablePickerFields(this);
		}

		#endregion
	}
}