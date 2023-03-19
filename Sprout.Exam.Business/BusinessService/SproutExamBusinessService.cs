using AutoMapper;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Business.Interfaces.Repository;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Business.Models.ViewModel;
using Sprout.Exam.Business.Response;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprout.Exam.Business.BusinessService
{
   public class SproutExamBusinessService : ISproutExamBusinessService
    {
        private readonly ISproutExamRepository _sproutExamRepository;
        private readonly ISalaryService  _salaryService;


        private readonly IMapper _mapper;
        public SproutExamBusinessService(ISproutExamRepository sproutExamRepository, IMapper mapper, ISalaryService salaryService)
        {
            _sproutExamRepository = sproutExamRepository;
            _mapper = mapper;
            _salaryService = salaryService;
        }
        public async Task<List<EmployeeVM>> GetEmployee()
        {
            return _mapper.Map<List<EmployeeVM>> (await _sproutExamRepository.GetEmployees());
            throw new BaseResponse();
          
        }

        public async Task<bool> EditEmployee(EmployeeEntity employeeEntity)
        {
            var result =  await _sproutExamRepository.EditEmployee(employeeEntity);
            return result;
            throw new BaseResponse("Employee Update Failed");

        }

        public async Task<EmployeeVM> GetEmployeeDetails(int employeeID)
        {
          

            return _mapper.Map<EmployeeVM>(await _sproutExamRepository.GetEmployeeDetails(employeeID));
          
            throw new BaseResponse("Update  Failed");

        }

        public async Task<int> DeleteEmployee(int id)
        {
            var res = new EmployeeVM();
           var result =  await _sproutExamRepository.DeleteEmployee(id);
            if(result)
            {
                 res = await GetEmployeeDetails(id);
            }
            return res.Id;
            throw new BaseResponse("Delete  Failed");
        }

        public async Task<int> CreateEmployee(CreateEmployeeDto employeeEntity)
        {
            var result = await _sproutExamRepository.CreateEmployee(employeeEntity);
            return result;
            throw new BaseResponse("Creation  Failed");
        }

        public async Task <decimal> CalculateSalary(SalaryEntity salaryEntity)
        {
            var employee = await _sproutExamRepository.GetEmployeeDetails(salaryEntity.Id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }
            var type = (EmployeeType)employee.EmployeeTypeId;
            switch (type)
            {
                case EmployeeType.Regular:
                    return _salaryService.RegularSalary(salaryEntity);
                case EmployeeType.Contractual:
                    return _salaryService.ContractualSalary(salaryEntity);


                case EmployeeType.Probitionary:
                    return _salaryService.ProbitionarySalary(salaryEntity);


                case EmployeeType.PartTime:
                    return _salaryService.PartTimeSalary(salaryEntity);

                default:
                    throw new ArgumentException("Employee type not found");
            }

        }


    }
}
