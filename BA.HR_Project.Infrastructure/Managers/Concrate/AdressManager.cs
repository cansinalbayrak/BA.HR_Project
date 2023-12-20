using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrasturucture.Managers.Concrate
{
    public class AdressManager : BaseManager<Adress,AdressDto> , IAdressService
    {
        public AdressManager(IMapper mapper , IUow uow) : base(mapper , uow)
        {
            
        }
    }
}
