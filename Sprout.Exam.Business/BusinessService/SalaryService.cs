using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.BusinessService
{
   public class SalaryService  : ISalaryService
    {
        public   decimal RegularSalary(SalaryEntity salary)
        {
            decimal basicMonthlySalary = salary.BasicMonthlySalary;
            decimal daysAbsent = salary.DaysAbsent ;


            decimal taxRate = 0.12m;
            decimal dailyRate = basicMonthlySalary / 22m;
            decimal grossPay = dailyRate * (22 - daysAbsent);


            decimal tax = grossPay * taxRate;
            decimal netPay =  grossPay - tax;

            return  Math.Round(netPay, 2);
        }


        public  decimal ContractualSalary(SalaryEntity salary)
        {
            decimal ratePerDay = salary.DailyRate;
            decimal daysWorked = salary.WorkedDays;

            decimal grossPay = ratePerDay * daysWorked;

            return grossPay;
        }

        public decimal ProbitionarySalary(SalaryEntity salary)
        {
            decimal basicMonthlySalary = salary.BasicMonthlySalary;
            decimal daysAbsent = salary.DaysAbsent;
            decimal taxRate = 0.12m;
            decimal dailyRate = basicMonthlySalary / 22m;
            decimal grossPay = dailyRate * (22 - daysAbsent);
            decimal tax = grossPay * taxRate;
            decimal netPay = grossPay - tax;
            return netPay;
        }

        public decimal PartTimeSalary(SalaryEntity salary)
        {
            decimal ratePerHour = salary.RatePerHour;
            decimal hoursWorked = salary.HoursWorked;
            decimal grossPay = ratePerHour * hoursWorked;
            decimal netPay = grossPay;

            return netPay;
        }
    }
}
