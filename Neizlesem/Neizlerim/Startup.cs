using BusinesLogicLayer.Abstarct;
using BusinesLogicLayer.Coctere;
using BusinesLogicLayer.Concrete;
using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Context.EntityFramework;
using DataAccessLayer.SeedData;
using Entity.POCO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategory>();
            services.AddScoped<IFilmService, FilmManager>();
            services.AddScoped<IFilmDAL, EfFilm>();
            services.AddDbContext<NeizlesemDbContext>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequiredLength = 3;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
                x.User.RequireUniqueEmail = true;
             
            })

                .AddEntityFrameworkStores<NeizlesemDbContext>();
               // .AddErrorDescriber<ErrorDiscriberAccount>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //MyClass.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "AreaAdmin", areaName: "Admin", pattern: "{controller=film}/{action=Index}/{id?}"); ;
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
