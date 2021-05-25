using System.Collections.Generic;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;

using Kentico.Content.Web.Mvc;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of site Employees.
    /// </summary>
    public class EmployeeRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class that returns Employees.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public EmployeeRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }


        /// <summary>
        /// Returns an enumerable collection of Employees ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<PageEmployee> GetEmployees(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<PageEmployee>(
                query => query
                    .Path(nodeAliasPath, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(EmployeeRepository)}|{nameof(GetEmployees)}|{nodeAliasPath}")
                    .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()));
        }
    }
}