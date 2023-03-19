using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Business.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interfaces
{
   public interface ISproutExamBusinessService
    {
        Task<List<EmployeeVM>> GetEmployee();
        Task<bool> EditEmployee(EmployeeEntity employeeEntity);
        Task<EmployeeVM> GetEmployeeDetails(int  employeeID);
        Task<int> DeleteEmployee(int id);
        Task<int> CreateEmployee(CreateEmployeeDto employeeEntity);
        Task<decimal> CalculateSalary(SalaryEntity salaryEntity);

    }
}
