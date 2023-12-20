using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;

namespace BA.HR_Project.WEB.Mapping
{
    public class LoginUserViewModelMapping:Profile
    {
        public LoginUserViewModelMapping()
        {
            CreateMap<LoginUserViewModel, LoginUserDto>().ReverseMap();
        }
        
    }
}
