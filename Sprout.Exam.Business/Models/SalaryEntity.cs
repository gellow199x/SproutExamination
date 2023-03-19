using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models
{
    public class SalaryEntity 
    {
        public decimal WorkedDays { get; set; }
        public decimal BasicMonthlySalary { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal DaysAbsent { get; set; }
        public decimal DailyRate { get; set; }
        public decimal RatePerHour { get; set; }
        public int EmploymentType { get; set; }
        public int Id { get; set; }


    }
}
