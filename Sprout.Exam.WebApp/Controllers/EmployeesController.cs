using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Business.Models;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        /// 
        private readonly ISproutExamBusinessService _sproutExamBusinessService;
        //private readonly IWebHelper _helper;
        private readonly IHttpContextAccessor _contextAccessor;
        //private readonly ILogger _logger;

        public EmployeesController(ISproutExamBusinessService sproutExamBusinessService, IHttpContextAccessor accessor)

        {
            _sproutExamBusinessService = sproutExamBusinessService;
            _contextAccessor = accessor;
            
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _sproutExamBusinessService.GetEmployee();
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sproutExamBusinessService.GetEmployeeDetails(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto employeeDetails)
        {
          var result =  await _sproutExamBusinessService.EditEmployee(new EmployeeEntity { 
              Birthdate  = employeeDetails.Birthdate,
              FullName = employeeDetails.FullName,
              Tin = employeeDetails.Tin,
              TypeId = employeeDetails.TypeId,
               Id = employeeDetails.Id,

          });

            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto employeeEntity)
        {
            var id = await _sproutExamBusinessService.CreateEmployee(employeeEntity);
            if (id == 0)
            {
                return NotFound();
            }
            return Created($"/api/employees/{id}", id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _sproutExamBusinessService.DeleteEmployee(id);
            if (result == 0)
            {
                return NotFound();
            }


            return Ok(result);
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
      

        public async  Task<IActionResult> Calculate(int id, [FromBody] SalaryEntity salary)
        {

            var result = await _sproutExamBusinessService.CalculateSalary(salary);
            return Ok(result);
        }

    }
}
