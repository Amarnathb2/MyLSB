using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class ColumnsViewComponent : ViewComponent
    {
        private readonly ColumnRepository columnRepository;

        public ColumnsViewComponent(ColumnRepository columnRepository)
        {
            this.columnRepository = columnRepository;
        }

        public IViewComponentResult Invoke(Columns node)
        {
            var columns = columnRepository.GetColumns(node.NodeAliasPath);

            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/Columns/ColumnsContainer.cshtml", columns);
            }
            return View("~/Components/ViewComponents/Columns/Columns.cshtml", columns);
        }
    }
}