using BA.HR_Project.Application.Interfaces.Repositories;
using BA.HR_Project.Domain.Common;
using BA.HR_Project.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Persistance.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _dbSet.Remove(entity)) ;
        }

        public async Task<List<T>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null) 
            {
              query = query.Where(filter);
            
            }
            if (includeProperties.Any()) 
            {
              foreach (var property in includeProperties) 
                {
                  query = query.Include(property);
                
                }
            
            
            }
            if (asNoTracking) 
            {
              query= query.AsNoTracking();
            
            }
            var rslt = await query.ToListAsync();
            return rslt;
            
        }

        public async Task<T> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query = _dbSet;


            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);

                }


            }
            if (asNoTracking)
            {
                query = query.AsNoTracking();

            }
            var result = await _dbSet.SingleAsync();
            return result;
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
        }
    }
}
