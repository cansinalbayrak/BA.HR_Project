using BA.HR_Project.Infrasturucture.RequestResponse;
using Microsoft.AspNetCore.Identity;

namespace BA.HR_Project.WEB.CustomMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private void HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;

            var response = new Response
            {
                IsSuccess = false,
                Message = "Some Error Occurred.",
                Errors = new List<IdentityError> { new IdentityError { Description = ex.Message } }
            };

            context.Items["Exception"] = response;

            var statusCode = context.Response.StatusCode;

            if (statusCode >= 400 && statusCode < 500)
            {
                // 400-404 hataları
                context.Response.Redirect("/Home/Warning");
            }
            else if (statusCode == 500)
            {
                // 500 hataları
                context.Response.Redirect("/Home/Error");
            }
        }
    }
}

