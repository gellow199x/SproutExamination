using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models.ViewModel
{
  public   class EmployeeVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Birthdate { get; set; }
        public string Tin { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
