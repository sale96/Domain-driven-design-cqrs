using DDDT.Application.Commands;
using DDDT.Implementation.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDT.API.Services
{
    public static class CommandServices
    {
        public static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
            services.AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>();

            return services;
        }
    }
}
