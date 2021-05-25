using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Components
{
    public class EmployeesViewComponent : ViewComponent
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeesViewComponent(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Employees node)
        {
            var employees = EmployeesViewModel.GetViewModel(node, employeeRepository);

            if (employees.Employees.Any())
            {
                return View("~/Components/ViewComponents/Employees/Employees.cshtml", employees);
            }

            return Content(String.Empty);
        }
    }
}
