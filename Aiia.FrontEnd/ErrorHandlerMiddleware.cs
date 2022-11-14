using System.Net;

namespace Aiia.FrontEnd
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                 HandleExceptionAsync(httpContext, ex);
            }
        }
        private void HandleExceptionAsync(HttpContext context, Exception exception)
        {
          context.Response.Redirect("/error");
        }
    }
}
