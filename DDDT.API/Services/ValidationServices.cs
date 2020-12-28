using DDDT.Implementation.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDT.API.Services
{
    public static class ValidationServices
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateGroupValidator>();
            services.AddTransient<RegisterUserValidator>();

            return services;
        }
    }
}
