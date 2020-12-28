using DDDT.Application.Commands;
using DDDT.Implementation.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DDDT.API.Services
{
    public static class CommandServices
    {
        public static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
            services.AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>();
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();

            return services;
        }
    }
}
