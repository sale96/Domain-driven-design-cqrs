using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDT.API.Core;
using DDDT.API.Services;
using DDDT.Application;
using DDDT.Application.Commands;
using DDDT.EfDataAccess;
using DDDT.Implementation.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DDDT.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DDDTContext>();

            services.RegisterCommands();
            services.RegisterValidators();

            services.AddTransient<IApplicationActor, FakeApiActor>();
            services.AddTransient<UseCaseExecutor>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
