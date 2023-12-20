using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;

namespace InsanKaynaklarıProjesi.WEB.Mapping
{
    public class ListSummarInfoViewModelMapping:Profile
    {
        public ListSummarInfoViewModelMapping()
        {
            CreateMap<ListSummarInfoViewModel,ListDetailInfoDto>().ReverseMap();
        }
    }
}
