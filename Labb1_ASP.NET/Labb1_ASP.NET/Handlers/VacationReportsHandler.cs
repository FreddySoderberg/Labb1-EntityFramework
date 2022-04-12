using Labb1_ASP.NET.DbContextHandlers;
using Labb1_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1_ASP.NET.Handlers
{
    public class VacationReportsHandler
    {
        //Gets all VacationReports
        public static List<VacationReport> GetReports()
        {
            var reportList = new List<VacationReport>();
            using (var context = new DbContextHandler())
            {
                reportList = context.VacationsReports.ToList();
            }
            return reportList;
        }

        //Gets VacationReports, but includes all FKey employees
        public static List<VacationReport> GetReportsWithEmployee()
        {
            using (var context = new DbContextHandler())
            {
                List<VacationReport> reportList = context.VacationsReports.Include(x => x.Employee).ToList();
                return reportList;
            }
        }

        // Search Reports with a name, by using Contains
        public static List<VacationReport> SearchReportsByName(string search)
        {
            using (var context = new DbContextHandler())
            {
                List<VacationReport> reportList = context.VacationsReports.Include(x => x.Employee).Where(x => x.Employee.EmployeeName.ToLower().Contains(search)).ToList();
                return reportList;
            }
        }

        //Creates a VacationReport and adds it to the table
        public static void CreateVacationReport(string typeOfLeave, DateTime startDate, DateTime endDate, int employeeId)
        {
            using (var context = new DbContextHandler())
            {
                var employeeList = context.Employees.ToList();

                foreach (var employee in employeeList)
                {
                    if (employee.EmployeeId == employeeList[employeeId - 1].EmployeeId)
                    {
                        var report = new VacationReport { TypeOfLeave = typeOfLeave, StartDate = startDate, EndDate = endDate, CurrentDate = DateTime.Now, Employee = employeeList[employeeId - 1] };
                        context.VacationsReports.Add(report);
                    }
                }
                context.SaveChanges();
            }
        }

        //Search all reports by entering a month
        public static List<VacationReport> SearchReportsByMonth(string monthSearch)
        {

            using (var context = new DbContextHandler())
            {
                int monthNum = Int32.Parse(monthSearch);
                List<VacationReport> reportList = context.VacationsReports.Where(r => r.CurrentDate.Month == monthNum).Include(x => x.Employee).ToList();
                return reportList;
            }
        }
    }
}
