using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using MyClinicProject;
using MyClinicProject.Storage;
using MyClinicProject.Models;

namespace MyClinicMvc
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
            services.AddControllersWithViews();

            //var patientStorage = new PatientStorageList();

            string connectionString = "Host=raja.db.elephantsql.com;Database=efriivgt;Username=efriivgt;Password=TaSKp23YiEPDFQqV0kzN4NUVq9KQHicd;";
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("MyClinicMvc")));
            
            //options.UseSqlServer(connection, b => b.MigrationsAssembly("MyClinicMvc")).
            
            services.AddScoped<IStorePatient, PatientStorageEF>();
            services.AddScoped<MyClinicSystem>();
            
            // var patientStorage = new PatientStorageEF();

            // var myclinic = new MyClinicSystem(patientStorage);

            // services.AddSingleton<MyClinicSystem>(myclinic);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
