using BA.HR_Project.Application.Interfaces.Repositories;
using BA.HR_Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.Interfaces
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        Task SaveChanges();
    }
}
