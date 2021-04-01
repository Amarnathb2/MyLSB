using System;
using System.Data;

using CMS.Base;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.SiteProvider;

namespace URLRedirection
{    
    /// <summary>
    /// Class providing RedirectionTableInfo management.
    /// </summary>
    public class RedirectionTableInfoProvider : AbstractInfoProvider<RedirectionTableInfo, RedirectionTableInfoProvider>
    {
        #region "Constructors"

        /// <summary>
        /// Constructor
        /// </summary>
        public RedirectionTableInfoProvider()
            : base(RedirectionTableInfo.TYPEINFO)
        {
        }

        #endregion


        #region "Public methods - Basic"

        /// <summary>
        /// Returns a query for all the RedirectionTableInfo objects.
        /// </summary>
        public static ObjectQuery<RedirectionTableInfo> GetRedirectionTables()
        {
            return ProviderObject.GetRedirectionTablesInternal();
        }


        /// <summary>
        /// Returns RedirectionTableInfo with specified ID.
        /// </summary>
        /// <param name="id">RedirectionTableInfo ID</param>
        public static RedirectionTableInfo GetRedirectionTableInfo(int id)
        {
            return ProviderObject.GetRedirectionTableInfoInternal(id);
        }


        /// <summary>
        /// Sets (updates or inserts) specified RedirectionTableInfo.
        /// </summary>
        /// <param name="infoObj">RedirectionTableInfo to be set</param>
        public static void SetRedirectionTableInfo(RedirectionTableInfo infoObj)
        {
            ProviderObject.SetRedirectionTableInfoInternal(infoObj);
        }


        /// <summary>
        /// Deletes specified RedirectionTableInfo.
        /// </summary>
        /// <param name="infoObj">RedirectionTableInfo to be deleted</param>
        public static void DeleteRedirectionTableInfo(RedirectionTableInfo infoObj)
        {
            ProviderObject.DeleteRedirectionTableInfoInternal(infoObj);
        }


        /// <summary>
        /// Deletes RedirectionTableInfo with specified ID.
        /// </summary>
        /// <param name="id">RedirectionTableInfo ID</param>
        public static void DeleteRedirectionTableInfo(int id)
        {
            RedirectionTableInfo infoObj = GetRedirectionTableInfo(id);
            DeleteRedirectionTableInfo(infoObj);
        }

        #endregion


        #region "Public methods - Advanced"


        /// <summary>
        /// Returns a query for all the RedirectionTableInfo objects of a specified site.
        /// </summary>
        /// <param name="siteId">Site ID</param>
        public static ObjectQuery<RedirectionTableInfo> GetRedirectionTables(int siteId)
        {
            return ProviderObject.GetRedirectionTablesInternal(siteId);
        }

        /// <summary>
        /// Returns a query for all the RedirectionTableInfo objects of a specified site and where condition.
        /// </summary>
        /// <param name="where">where</param>
        /// <param name="siteId">Site ID</param>
        public static ObjectQuery<RedirectionTableInfo> GetRedirectionTables(string where, int siteId)
        {
            return ProviderObject.GetRedirectionTablesInternal(where, siteId);
        }
        
        #endregion


        #region "Internal methods - Basic"
	
        /// <summary>
        /// Returns a query for all the RedirectionTableInfo objects.
        /// </summary>
        protected virtual ObjectQuery<RedirectionTableInfo> GetRedirectionTablesInternal()
        {
            return GetObjectQuery();
        }    


        /// <summary>
        /// Returns RedirectionTableInfo with specified ID.
        /// </summary>
        /// <param name="id">RedirectionTableInfo ID</param>        
        protected virtual RedirectionTableInfo GetRedirectionTableInfoInternal(int id)
        {	
            return GetInfoById(id);
        }


        /// <summary>
        /// Sets (updates or inserts) specified RedirectionTableInfo.
        /// </summary>
        /// <param name="infoObj">RedirectionTableInfo to be set</param>        
        protected virtual void SetRedirectionTableInfoInternal(RedirectionTableInfo infoObj)
        {
            SetInfo(infoObj);
        }


        /// <summary>
        /// Deletes specified RedirectionTableInfo.
        /// </summary>
        /// <param name="infoObj">RedirectionTableInfo to be deleted</param>        
        protected virtual void DeleteRedirectionTableInfoInternal(RedirectionTableInfo infoObj)
        {
            DeleteInfo(infoObj);
        }	

        #endregion

        #region "Internal methods - Advanced"


        /// <summary>
        /// Returns a query for all the RedirectionTableInfo objects of a specified site.
        /// </summary>
        /// <param name="siteId">Site ID</param>
        protected virtual ObjectQuery<RedirectionTableInfo> GetRedirectionTablesInternal(int siteId)
        {
            return GetObjectQuery().OnSite(siteId);
        }

        /// <summary>
        /// Returns a query for all the RedirectionTableInfo objects of a specified site and where condition.
        /// </summary>
        /// <param name="where">where</param>
        /// <param name="siteId">Site ID</param>
        protected virtual ObjectQuery<RedirectionTableInfo> GetRedirectionTablesInternal(string where, int siteId)
        {
            return GetObjectQuery().WhereEquals("RedirectionOriginalURL",where).OnSite(siteId);
        }    
        
        #endregion		
    }
}