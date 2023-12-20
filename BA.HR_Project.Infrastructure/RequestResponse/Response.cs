using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrasturucture.RequestResponse
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; } = new List<IdentityError>();

        public static Response Success(string message = "")
        {
            return new Response { IsSuccess = true, Message = message };
        }

        public static Response Failure(string message)
        {
            return new Response { IsSuccess = false, Message = message };
        }
        public static Response Failure(IEnumerable<IdentityError> errors)
        {
            return new Response { IsSuccess = false, Message = "Multiple errors", Errors = errors };
        }
    }

    public class Response<T> : Response where T : class
    {
        public T Context { get; set; }

        public static new Response<T> Success(T context, string message = "")
        {
            return new Response<T> { IsSuccess = true, Message = message, Context = context };
        }

        public static new Response<T> Failure(string message)
        {
            return new Response<T> { IsSuccess = false, Message = message };
        }
    }
}
