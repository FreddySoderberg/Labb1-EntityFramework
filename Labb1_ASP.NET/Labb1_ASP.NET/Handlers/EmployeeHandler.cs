using Labb1_ASP.NET.DbContextHandlers;
using Labb1_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1_ASP.NET.Handlers
{
    class EmployeeHandler
    {
        //Get Employee through ID
        public static Employee GetEmployeeById(int employeeId)
        {
            using (var context = new DbContextHandler())
            {
                var employeeList = context.Employees.ToList();

                foreach (var employee in employeeList)
                {
                    if (employee.EmployeeId == employeeId)
                    {
                        return employee;
                    }
                }
                Console.WriteLine("Employee was not found");
                return null;
            }
        }

        //Gets all employees from DB in a list
        public static List<Employee> GetEmployees()
        {
            var employeeList = new List<Employee>();
            using (var context = new DbContextHandler())
            {
                employeeList = context.Employees.ToList();
            }
            return employeeList;
        }
    }
}
