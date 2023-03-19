using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Configurations
{
   public  interface IDbConfiguration
    {
        IDbConnection CreateDatabase(string connectionString);
    }
}
