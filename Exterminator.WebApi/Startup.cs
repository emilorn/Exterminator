using Exterminator.Repositories.Data;
using Exterminator.Repositories.Implementations;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Implementations;
using Exterminator.Services.Interfaces;
using Exterminator.WebApi.ExceptionHandlerExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Exterminator.WebApi
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
            services.AddMvc();
            // TODO: Register dependencies
            services.AddControllers();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IGhostbusterRepository, GhostbusterRepository>();
            services.AddTransient<IGhostbusterService, GhostbusterService>();
            services.AddTransient<IGhostbusterDbContext, GhostbusterDbContext>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // TODO: Setup global exception handling
            //app.UseMvc();
            app.UseRouting();
            app.UseGlobalExceptionHandler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
