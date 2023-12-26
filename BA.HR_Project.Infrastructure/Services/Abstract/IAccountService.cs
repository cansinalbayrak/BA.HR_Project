using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Infrasturucture.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Abstract
{
    public interface IAccountService
    {
        Task<Response> LogInAsync(LoginUserDto loginUserDto);
        Task SignOutAsync();
    }
}
