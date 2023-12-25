using BA.HR_Project.Infrasturucture.RequestResponse;
using Microsoft.AspNetCore.Identity;

namespace BA.HR_Project.WEB.CustomMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var response = new Response
                {
                    IsSuccess = false,
                    Message = "Some Error Occurred.",
                    Errors = new List<IdentityError> { new IdentityError { Description = ex.Message } }
                };

                context.Items["Exception"] = response;

                if (context.Response.StatusCode >= 400 && context.Response.StatusCode < 500)
                {
                    context.Response.Redirect("/Home/Warning");
                }
                else
                {
                    context.Response.Redirect("/Home/Error");
                }
            }

            // Sign In sırasındaki hata kontrolü
            if (context.Request.Path == "/Home/Account/Login" && context.Response.StatusCode == 404)
            {
                context.Response.StatusCode = 500;

                var response = new Response
                {
                    IsSuccess = false,
                    Message = "Some Error Occurred during Sign In.",
                    Errors = new List<IdentityError> { new IdentityError { Description = "Sign In Error" } }
                };

                context.Items["Exception"] = response;
                context.Response.Redirect("/Home/Warning");
            }
        }
    }
}

