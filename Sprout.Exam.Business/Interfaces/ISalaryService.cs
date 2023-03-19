using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interfaces
{
    public interface ISalaryService
    {
        decimal RegularSalary(SalaryEntity salary);
        decimal ContractualSalary(SalaryEntity salary);
        decimal PartTimeSalary(SalaryEntity salary);
        decimal ProbitionarySalary(SalaryEntity salary);
    }
}
