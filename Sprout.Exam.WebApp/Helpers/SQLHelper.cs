
using Microsoft.Extensions.Configuration;
using Sprout.Exam.Business.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Helpers
{
    public class SQLHelper : ISQLHelper
    {
        private readonly IConfiguration _configuration;
        public SQLHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string DefaultConnection => _configuration.GetSection("ConnectionStrings:DefaultConnection")?.Value;

      
    }
}
