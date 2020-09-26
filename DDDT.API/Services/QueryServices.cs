using DDDT.Application.Queries;
using DDDT.Implementation.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDT.API.Services
{
    public static class QueryServices
    {
        public static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetGroupsQuery, EfGetGroupsQuery>();

            return services;
        }
    }
}
