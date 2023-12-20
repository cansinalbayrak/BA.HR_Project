using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Persistance.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using BA.HR_Project.Application.Interfaces.Repositories;
using BA.HR_Project.Persistance.Repositories;

namespace BA.HR_Project.Persistance.Extensions
{
    public static class PersistanceDependencies
    {
        public static void AddPersistanceDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUow, Uow>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
    }

