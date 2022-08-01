using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CalculaJuros.Middleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            var context = httpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; // Your exception
           
            if(exception != default)
            {
                if(exception is ValidationException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsJsonAsync(new { error = "teste" });
                }
            }

           

        }

    }
}
