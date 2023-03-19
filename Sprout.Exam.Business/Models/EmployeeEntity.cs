using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models
{
   public  class EmployeeEntity
    {
       
        public int Id { get; set; }
     
        public string FullName { get; set; }
    
        public DateTime Birthdate { get; set; }
   
        public string Tin { get; set; }
       
        public int TypeId { get; set; }
    }
}
