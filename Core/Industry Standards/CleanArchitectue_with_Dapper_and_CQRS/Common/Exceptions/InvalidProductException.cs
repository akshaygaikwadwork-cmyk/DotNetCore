using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class InvalidProductException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public InvalidProductException(string message)
            : base(message)
        {
        }
    }
}
