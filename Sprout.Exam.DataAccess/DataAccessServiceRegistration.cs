using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Business.Interfaces.Repository;
using Sprout.Exam.Common;
using Sprout.Exam.DataAccess.Models;
using Sprout.Exam.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Interface
            var dictConnections = new Dictionary<Database, string>
            {
                { Database.DefaultConnection, configuration.GetConnectionString("DefaultConnection") },
               
            };
            services.AddSingleton<IDictionary<Database, string>>(dictConnections);
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();
            services.AddTransient<ISproutExamRepository, SproutExamRepository>();
            #endregion

            return services;
        }
    }
}
