using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Response
{
    public class BaseResponse : ApplicationException
    {
        public BaseResponse() : base()
        {
            Success = true;
        }
        public BaseResponse(string message) : base(message)
        {
            Success = true;
            //Message = message;
        }

        public BaseResponse(string message, object key) : base($"{message})") { }

        public bool Success { get; set; }
    }
}
