using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleAPI.Infrastructure;
using SimpleAPI.Services;

namespace SimpleAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
           // Configuration = configuration;
            var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .AddControllersAsServices();

            services.AddTransient(typeof(Repository));
            services.AddSingleton<IConfiguration>(Configuration);

            var connString = Environment.GetEnvironmentVariable("CONN_STRING");

            services.AddDbContext<ToDoContext>(c =>
            {
                c.UseSqlServer(connString);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => 
            {
                options.WithOrigins("http://localhost:4200");
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowCredentials();
            });

            app.UseMvc();            
        }
    }
}
