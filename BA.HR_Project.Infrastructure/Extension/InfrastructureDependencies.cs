using BA.HR_Project.Infrastructure.Managers.Abstract;
using BA.HR_Project.Infrastructure.Managers.Concrate;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Extension
{
    public static class InfrastructureDependencies
    {
        public static  void AddInfrastructureDependencies(this IServiceCollection services) 
        {
            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IEmailService, EmailManager>();



            services.AddScoped<IDayOffService, DayOffManager>();
            services.AddScoped<IAdvanceService, AdvanceManager>();
            services.AddScoped<IExpsenseService, ExpenseManager>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeManager>();
            


        }
    }
}
