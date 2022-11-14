using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class BussinessException : Exception
    {
        public string ExceptionId;

        public string ExceptionDetails { get; set; }
        public ApplicationMessage AppMessage { get; set; }

        public BussinessException()
        {

        }

        public BussinessException(string exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BussinessException(string exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
        }
    }
}
