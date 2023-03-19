using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Models
{
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<Database, string> _dictConnections;
        public DapperDbConnectionFactory(IDictionary<Database, string> dictConnections)
        {
            _dictConnections = dictConnections;
        }

        public System.Data.IDbConnection CreateDbConnection(Database connectionName)
        {
            //var connectionString = string.Empty;

            if (_dictConnections.TryGetValue(connectionName, out var connectionString))
            {
                return new SqlConnection(connectionString);
            }

            throw new ArgumentNullException();
        }
    }
}
