using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(in int statusCode)
        {
            return statusCode switch
                {
                    400=>"error 400, you have made a bad request",
                    401=> "error 401,you are not authorized",
                    404=> "error 404 ,request not found",
                    500=>
                    "error 500",
                    _ => null
                };
        }
    }
}
