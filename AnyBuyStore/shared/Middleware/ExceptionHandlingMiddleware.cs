using AnyBuyStore.shared.Exceptions;
using System.Net;

namespace AnyBuyStore.Middleware
{
    public class ExceptionHandlingMiddleware :IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (DomainNotFoundException e)
            {

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
               await  context.Response.WriteAsync(e.Message);                    
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
