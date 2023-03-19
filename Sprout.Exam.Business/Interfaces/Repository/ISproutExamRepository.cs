using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interfaces.Repository
{
    public interface ISproutExamRepository
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<bool> EditEmployee(EmployeeEntity employeeEntity);
        Task<EmployeeDto> GetEmployeeDetails(int employeeID);
        Task<bool> DeleteEmployee(int id);
        Task<int> CreateEmployee(CreateEmployeeDto employeeEntity);

    }
}
