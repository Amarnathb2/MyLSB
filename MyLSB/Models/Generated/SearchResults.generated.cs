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

[assembly: RegisterDocumentType(SearchResults.CLASS_NAME, typeof(SearchResults))]

namespace CMS.DocumentEngine.Types.Custom
{
	/// <summary>
	/// Represents a content item of type SearchResults.
	/// </summary>
	public partial class SearchResults : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "custom.SearchResults";


		/// <summary>
		/// The instance of the class that provides extended API for working with SearchResults fields.
		/// </summary>
		private readonly SearchResultsFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// SearchResultsID.
		/// </summary>
		[DatabaseIDField]
		public int SearchResultsID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("SearchResultsID"), 0);
			}
			set
			{
				SetValue("SearchResultsID", value);
			}
		}


		/// <summary>
		/// SearchResultsName.
		/// </summary>
		[DatabaseField]
		public string SearchResultsName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SearchResultsName"), @"Search Results");
			}
			set
			{
				SetValue("SearchResultsName", value);
			}
		}


		/// <summary>
		/// Search Index.
		/// </summary>
		[DatabaseField]
		public string SearchResultsSearchIndex
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SearchResultsSearchIndex"), @"");
			}
			set
			{
				SetValue("SearchResultsSearchIndex", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with SearchResults fields.
		/// </summary>
		[RegisterProperty]
		public SearchResultsFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with SearchResults fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class SearchResultsFields : AbstractHierarchicalObject<SearchResultsFields>
		{
			/// <summary>
			/// The content item of type SearchResults that is a target of the extended API.
			/// </summary>
			private readonly SearchResults mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="SearchResultsFields" /> class with the specified content item of type SearchResults.
			/// </summary>
			/// <param name="instance">The content item of type SearchResults that is a target of the extended API.</param>
			public SearchResultsFields(SearchResults instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// SearchResultsID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.SearchResultsID;
				}
				set
				{
					mInstance.SearchResultsID = value;
				}
			}


			/// <summary>
			/// SearchResultsName.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.SearchResultsName;
				}
				set
				{
					mInstance.SearchResultsName = value;
				}
			}


			/// <summary>
			/// Search Index.
			/// </summary>
			public string SearchIndex
			{
				get
				{
					return mInstance.SearchResultsSearchIndex;
				}
				set
				{
					mInstance.SearchResultsSearchIndex = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="SearchResults" /> class.
		/// </summary>
		public SearchResults() : base(CLASS_NAME)
		{
			mFields = new SearchResultsFields(this);
		}

		#endregion
	}
}