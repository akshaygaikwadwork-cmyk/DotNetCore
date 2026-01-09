using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

        public ProductNotFoundException(int productId)
            : base($"Product with ID {productId} was not found.")
        {
        }
    }
}
