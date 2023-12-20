using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.Extentios
{
    public static class CoreDepecenies
    {
        public static void AddCoreDepecenies(this IServiceCollection services,Assembly assemblyFromUi)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly(),assemblyFromUi);

        }
    }
}
