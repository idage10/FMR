using FlightAlertData.Alert;
using FlightAlertData.Models;
using FlightAlertLogic.Alert;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAlertManagement
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
            // Add services to the container
            services.AddControllers();

            // Add dependency injection
            services.AddScoped<IAlertLogic, AlertLogic>();
            services.AddScoped<IAlertData, AlertData>();

            // Add DBContext
            services.AddDbContext<FlightContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            // Enable Cross-origin resource sharing (CORS)
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                     options.AllowAnyOrigin(). // Allow any header, including content-type
                     AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Configure controller route pattern
            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllerRoute(
                    name: "default", 
                    pattern: "Alerts/{controller=AlertManagement}/{action=Index}/{id?}"); 
            });

            app.UseCors("AllowOrigin");
        }
    }
}
