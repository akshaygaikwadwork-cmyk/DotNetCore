using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ProductNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (InvalidProductException ex)
            {
                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions specifically
                await HandleSqlExceptionAsync(context, ex);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            var errorResponse = new { error = message };

            // Serialize the error response
            var jsonResponse = JsonConvert.SerializeObject(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(jsonResponse);
        }

        private static Task HandleSqlExceptionAsync(HttpContext context, SqlException ex)
        {
            // Extract the SQL error code and message
            var errorCode = ex.Number;
            var errorMessage = ex.Message;

            // Set a default status code if needed
            var statusCode = HttpStatusCode.InternalServerError;

            // You can choose to map specific error codes to different status codes here if desired
            // For simplicity, we are using InternalServerError for all SQL exceptions

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                error = "Database error occurred.",
                errorCode,
                errorMessage
            };

            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
