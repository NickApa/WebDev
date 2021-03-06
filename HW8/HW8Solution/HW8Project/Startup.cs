using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW8Project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HW8Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IConfiguration config; 

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string password = config["Password:secret"];
            //var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("AssignmentTrackerAzure"));
            //builder.Password = Configuration["AssignmentTrackerAzure"];

            services.AddControllersWithViews();
            services.AddDbContext<AssignmentsDbContext>(opts =>
            {
                //opts.UseSqlServer(Configuration["ConnectionStrings:AssignmentString"]);
                opts.UseSqlServer(Configuration.GetConnectionString("AssignmentTrackerAzure"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
