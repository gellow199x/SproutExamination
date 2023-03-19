using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprout.Exam.Business.DataTransferObjects;

namespace Sprout.Exam.WebApp
{
    public static class StaticEmployees
    {
        public static List<EmployeeDto> ResultList = new()
        {
            new EmployeeDto
            {
                Birthdate = new DateTime(1993-03-28),
                FullName = "Jane Doe",
                Id = 1,
                Tin = "123215413",
                EmployeeTypeId = 1
            },
            new EmployeeDto
            {
                Birthdate = new DateTime(1993 - 03 - 28),
                FullName = "John Doe",
                Id = 2,
                Tin = "957125412",
                EmployeeTypeId = 2
            }
        };
    }
}
