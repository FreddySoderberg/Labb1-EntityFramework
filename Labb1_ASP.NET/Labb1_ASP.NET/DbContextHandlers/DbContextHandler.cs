using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Labb1_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_ASP.NET.DbContextHandlers
{
    class DbContextHandler : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationReport> VacationsReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=EmployeeReportsDb;Integrated Security=True;");
        }


        // ------- IGNORE! THIS IS TO ADD DUMMY DATA!! ---------
        public static void CreateDummyReports()
        {
            using(var context = new DbContextHandler())
            {
                var employeeList = new List<Employee>();
                employeeList = context.Employees.ToList();

                foreach(var employee in employeeList)
                {
                    if (employee.EmployeeName != "Freddy" && employee.EmployeeName != "Laura")
                    {
                        var report = new VacationReport { TypeOfLeave = "Vacation", StartDate = DateTime.Now, EndDate = DateTime.Now, CurrentDate = DateTime.Now, Employee = employee};
                        context.VacationsReports.Add(report);
                    }
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyEmployees()
        {
            List<Employee> employeeList = new List<Employee>
            {
                new Employee{EmployeeName="Laura"},
                new Employee{EmployeeName="Freddy"},
                new Employee{EmployeeName="Johnny"},
                new Employee{EmployeeName="Rickard"},
                new Employee{EmployeeName="Ace"}
            };

            using (var context = new DbContextHandler())
            {
                foreach(var emp in employeeList)
                {
                    context.Employees.Add(emp);
                }
                context.SaveChanges();
            }
        }
    }
}
