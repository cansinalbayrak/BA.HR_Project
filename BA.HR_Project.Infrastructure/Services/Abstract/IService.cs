using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BA.HR_Project.Infrasturucture.Services.Abstract
{
    public interface IService<T, TDto> where T : class, IEntity where TDto : class
    {
        Task<Response> Insert(TDto dto);
        Task<Response> Update(TDto dto);
        Task<Response> Delete(TDto dto);

        Task<Response<TDto>> GetByIdAsync(string Id);
        Task<Response<TDto>> Get(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<Response<IEnumerable<TDto>>> GetAll();
    }
}
