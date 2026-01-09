using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CRUD_Operation_JqueryAJAX.Attribute
{
    public class ApplicationException_Handlercs : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ApplicationException_Handlercs(ILogger<ApplicationException_Handlercs> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;


                int statusCode;


                switch (true)
                {
                    case bool _ when exception is UnauthorizedAccessException:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        break;


                    case bool _ when exception is InvalidOperationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;


                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }


                _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");


                // Custom Exception message to be returned to the UI
                context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
            }

        }
    }
}