﻿using Sprout.Exam.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interfaces
{
    public  interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(Database connectionName);
    }
}
