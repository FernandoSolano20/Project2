using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class BusinessException : Exception
    {
        public string ExceptionId { get; set; }

        public string ExceptionDetails { get; set; }
        public ApplicationMessage AppMessage { get; set; }

        public BusinessException()
        {

        }

        public BusinessException(string exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BusinessException(string exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
        }
    }
}
