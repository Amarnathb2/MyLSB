using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class EmployeesViewModel : TreeNodeViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<PageEmployee> Employees { get; set; }

        protected EmployeesViewModel(TreeNode node) : base(node)
        {
        }

        public static EmployeesViewModel GetViewModel(Employees node, EmployeeRepository employeeRepository)
        {
            var employees = new List<PageEmployee>();

            if (node.EmployeesDisplay == "path")
            {
                foreach (var employee in employeeRepository.GetEmployees(node.EmployeesPath))
                {
                    employees.Add(employee);
                }
            }
            else if (node.EmployeesDisplay == "pages")
            {
                employees = CacheHelper.Cache(cs =>
                {
                    var selectedEmployees = node.Fields.Employees.OfType<PageEmployee>().ToList();

                    if (cs.Cached)
                    {
                        var cacheKeys = new List<string>() { $"nodeid|{node.NodeID}" };

                        foreach (var employee in selectedEmployees)
                        {
                            cacheKeys.Add($"nodeid|{employee.NodeID}");
                        }
                        cs.CacheDependency = CacheHelper.GetCacheDependency(cacheKeys);
                    }

                    return selectedEmployees;

                }, new CacheSettings(10, $"{nameof(EmployeesViewModel)}|{node.NodeID}"));
            }

            return new EmployeesViewModel(node)
            {
                Heading = node.EmployeesHeading,
                Employees = employees
            };
        }
    }
}
