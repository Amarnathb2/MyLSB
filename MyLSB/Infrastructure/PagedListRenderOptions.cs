using X.PagedList;
using X.PagedList.Mvc.Core;

namespace MyLSB.Helpers
{
    /// <summary>
    /// Customized render option definitions for X.PagedList.
    /// </summary>
    /// <remarks>
    /// For more customization options see https://github.com/kpi-ua/X.PagedList/blob/master/src/X.PagedList.Mvc/PagedListRenderOptions.cs.
    /// </remarks>
    public class PagedListRenderOptions : X.PagedList.Web.Common.PagedListRenderOptionsBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="CustomPagedListRenderOptions"/> class.
        /// </summary>
        public PagedListRenderOptions()
        {
            DisplayLinkToFirstPage = X.PagedList.Web.Common.PagedListDisplayMode.Never;
            DisplayLinkToLastPage = X.PagedList.Web.Common.PagedListDisplayMode.Never;
            MaximumPageNumbersToDisplay = 5;
            DisplayEllipsesWhenNotShowingAllPageNumbers = false;
            LinkToPreviousPageFormat = "<span class=\"far fa-arrow-left\" aria-hidden=\"true\"></span><span class=\"sr-only\">Previous</span>";
            LinkToNextPageFormat = "<span class=\"sr-only\">Next</span><span class=\"far fa-arrow-right\" aria-hidden=\"true\"></span>";
        }
    }
}