using Dapper;
using Microsoft.Extensions.Options;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Business.Interfaces.Helpers;
using Sprout.Exam.Business.Interfaces.Repository;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Common;
using Sprout.Exam.DataAccess.Configurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository
{
    public class SproutExamRepository : ISproutExamRepository
    {
        private readonly ISQLHelper _config;
        private readonly IDbConnection _sproutConfig;

        public SproutExamRepository(ISQLHelper sqlHelper, IDbConnectionFactory connection)
        {
            _sproutConfig = connection.CreateDbConnection(Database.DefaultConnection);
            _config = sqlHelper;
        }
        public async Task<List<EmployeeDto>> GetEmployees()
        {
                var SQL = "SELECT Id, FullName, Birthdate, TIN, EmployeeTypeId FROM  Employee WHERE IsDeleted != 1 ORDER BY Id DESC ";
                var result = await _sproutConfig.QueryAsync<EmployeeDto>(SQL, new { });
                return result.ToList();
            
        }
        public async Task<bool> EditEmployee(EmployeeEntity employeeEntity)
        {
            var SQL = "UPDATE Employee SET FullName = @FullName, Birthdate = @Birthdate, TIN = @TIN, EmployeeTypeId = @EmployeeTypeId WHERE Id = @Id ";
            var result =  await _sproutConfig.ExecuteAsync(SQL, new { 
                FullName = employeeEntity.FullName,
                Birthdate = employeeEntity.Birthdate,
                TIN = employeeEntity.Tin,
                EmployeeTypeId = employeeEntity.TypeId,
                Id = employeeEntity.Id

            });
            return result > 0;

        }

        public async Task<EmployeeDto> GetEmployeeDetails(int employeeID)
        {
            var SQL = "SELECT Id, FullName, Birthdate, TIN, EmployeeTypeId, IsDeleted FROM Employee WHERE Id =  @ID";
            var result = await _sproutConfig.QueryAsync<EmployeeDto>(SQL, new
            {
                ID = employeeID
            });
            return result.FirstOrDefault();

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var SQL = "UPDATE Employee SET IsDeleted = 1 WHERE Id = @Id ";
            var result = await _sproutConfig.ExecuteAsync(SQL, new
            {
                Id = id,
            });
            return result > 0;
        }

        public async Task<int> CreateEmployee(CreateEmployeeDto employeeEntity)
        {
            var SQL = "INSERT INTO Employee(FullName, Birthdate, TIN, EmployeeTypeId, IsDeleted) VALUES(@FullName, @Birthdate, @TIN, @TypeId, 0) SELECT SCOPE_IDENTITY() AS Id ";
            var result = await _sproutConfig.ExecuteScalarAsync(SQL, new
            {
                FullName = employeeEntity.FullName,
                Birthdate = employeeEntity.Birthdate,
                TIN = employeeEntity.Tin,
                TypeId = employeeEntity.TypeId,
               
            });
            return Convert.ToInt32(result) ;

        }

    }
}
