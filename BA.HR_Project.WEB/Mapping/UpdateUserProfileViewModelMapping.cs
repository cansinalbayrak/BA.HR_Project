using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;

namespace BA.HR_Project.WEB.Mapping
{
    public class UpdateUserProfileViewModelMapping:Profile
    {
        public UpdateUserProfileViewModelMapping()
        {
            CreateMap<UpdateUserProfileViewModel, UpdateUserProfile>().ReverseMap();
        }
    }
}
