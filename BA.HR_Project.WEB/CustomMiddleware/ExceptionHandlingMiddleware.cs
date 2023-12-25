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
                    Message = "Some Error Occured.",
                    Errors = new List<IdentityError> { new IdentityError { Description = ex.Message } }
                };

                context.Items["Exception"] = response;
                context.Response.Redirect("/Home/Error");
            }
        }
    }
}
