using CMS.CustomTables;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Repository
{
    public static class TableRepository
    {
        public static string[] GetTableColumns(string CustomTableClassName)
        {
            return CacheHelper.Cache(cs =>
            {
                var dci = DataClassInfoProvider.GetDataClassInfo(CustomTableClassName);

                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency($"cms.customtable|byguid|{dci.ClassGUID.ToString()}");
                }

                var form = new FormInfo(dci.ClassFormDefinition);
                var columns = form.GetFields(true, false, false).Select(x => x.ToString()).ToArray();

                return columns;

            }, new CacheSettings(10, $"CustomTable|Columns|{CustomTableClassName}"));
        }

        public static List<CustomTableItem> GetTableRows(string CustomTableClassName, string[] Columns)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency($"customtableitem.{CustomTableClassName}|all");
                }

                if (Columns != null)
                {
                    var table = CustomTableItemProvider.GetItems(CustomTableClassName)
                    .Columns(Columns)
                    .OrderBy("ItemOrder")
                    .ToList();

                    return table;
                }

                return null;

            }, new CacheSettings(10, $"CustomTable|Rows|{CustomTableClassName}"));
        }
    }
}