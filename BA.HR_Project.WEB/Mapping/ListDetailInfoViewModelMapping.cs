using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Components;

namespace BA.HR_Project.WEB.Mapping
{
    public class ListDetailInfoViewModelMapping:Profile
    {
        public ListDetailInfoViewModelMapping()
        {
           CreateMap<ListDetailInfoViewModel,ListDetailInfoDto>().ReverseMap();
        }
    }
}
