using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labb1_ASP.NET.Models
{
    public class VacationReport
    {
        [Key]
        public int ReportId { get; set; }
        public string TypeOfLeave { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CurrentDate { get; set; }
        [Required]
        public Employee Employee { get; set; }
    }
}
