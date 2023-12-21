using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Application.Interfaces.Repositories;
using BA.HR_Project.Persistance.Context;
using BA.HR_Project.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Persistance.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AppDbContext _context;
     
        public Uow(AppDbContext context)
        {
            _context = context;
            
        }
        public  async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        IRepository<T> IUow.GetRepository<T>()
        {
            return new GenericRepository<T>(_context);
        }
    }
}
