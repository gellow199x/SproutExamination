using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sprout.Exam.Infrastructure
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccesServices(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }
    }
}
