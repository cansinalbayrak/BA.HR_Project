using BA.HR_Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);

        void Update(T entity);

        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(string Id);
        Task<T> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);

    }
}
