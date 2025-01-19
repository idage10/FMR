using FlightAlertData.Alert;
using FlightAlertData.Models;
using FlightAlertData.User;
using FlightAlertLogic.Alert;
using FlightAlertLogic.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUserData, UserData>();

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

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Users/{controller=UserManagement}/{action=Index}/{id?}");
            });

            app.UseCors("AllowOrigin");
        }
    }
}
