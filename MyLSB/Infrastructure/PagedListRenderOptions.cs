using X.PagedList.Mvc.Core.Common;
using X.PagedList.Web.Common;

namespace MyLSB.Infrastructure
{
    /// <summary>
    /// Customized render option definitions for X.PagedList.
    /// </summary>
    /// <remarks>
    /// For more customization options see https://github.com/kpi-ua/X.PagedList/blob/master/src/X.PagedList.Mvc/PagedListRenderOptions.cs.
    /// </remarks>
    public class CustomPagedListRenderOptions : PagedListRenderOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="CustomPagedListRenderOptions"/> class.
        /// </summary>
        public CustomPagedListRenderOptions()
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never;
            DisplayLinkToLastPage = PagedListDisplayMode.Never;
            DisplayLinkToNextPage = PagedListDisplayMode.Always;
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always;
            MaximumPageNumbersToDisplay = 5;
            DisplayEllipsesWhenNotShowingAllPageNumbers = false;
            LinkToPreviousPageFormat = "Previous";
            LinkToNextPageFormat = "Next";
            LinkToIndividualPageFormat = "{0}";
            UlElementClasses = new string[] { "pagination", "justify-content-center" };
            LiElementClasses = new string[] { "page-item" };
            PageClasses = new string[] { "page-link" };
        }
    }
}