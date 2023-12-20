using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Abstract;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BA.HR_Project.Application.DTOs;
using System.Linq.Expressions;

namespace BA.HR_Project.Infrasturucture.Managers.Abstract
{
    public class BaseManager<T, TDto> : IService<T, TDto> where T : class, IEntity where TDto : class, IDTO
    {
        protected readonly IMapper _mapper;
        protected readonly IUow _uow;

        public BaseManager(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response> Delete(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().DeleteAsync(entity);
                _uow.SaveChanges();
                return Response.Success("Deletion was successful.");
            }
            catch
            {
                return Response.Failure("Deletion was unsuccessful");
            }
        }

        public async Task<Response<TDto>> Get(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var entity = await _uow.GetRepository<T>().GetAsync(asNoTracking, filter, includeProperties);
                var dto = _mapper.Map<TDto>(entity);
                return Response<TDto>.Success(dto, "Acquirement was successful.");
            }
            catch
            {
                return Response<TDto>.Failure("Acquirement was unsuccessful");
            }
        }


        public async Task<Response<IEnumerable<TDto>>> GetAll()
        {
            try
            {
                var entities = _uow.GetRepository<T>().GetAllAsync(true);
                var dtos = _mapper.Map<List<TDto>>(entities);
                return Response<IEnumerable<TDto>>.Success(dtos, "Acquirement was successful.");
            }
            catch
            {
                return Response<IEnumerable<TDto>>.Failure("Acquirement was unsuccessful");
            }
        }

        public async Task<Response> Insert(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().InsertAsync(entity);
                _uow.SaveChanges();
                return Response.Success("Insertion was successful.");
            }
            catch
            {
                return Response.Failure("Insertion was unsuccessful");
            }
        }

        public async Task<Response> Update(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().UpdateAsync(entity);
                _uow.SaveChanges();
                return Response.Success("Updating was successful.");
            }
            catch
            {
                return Response.Failure("Updating was unsuccessful");
            }
        }
    }
}
