using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineTest.App.Controllers;
using OnlineTest.Core.Interfaces;
using OnlineTest.Core.Models;
using OnlineTest.Infrastructure.Data;
using OnlineTest.Infrastructure.Data.IdentityModels;
using OnlineTest.Infrastructure.Repositories;

namespace OnlineTest.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<OnlineTestDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("OnlineTestDb")));
         
           
            services.AddDefaultIdentity<AppUser>().AddRoles<AppRole>()
        .AddEntityFrameworkStores<OnlineTestDbContext>();



            services.AddControllersWithViews();
           services.AddHealthChecks();
            //services.AddAuthorization();
            services.AddAutoMapper(typeof(Startup));


            services.AddTransient<QuestionRepo>();
            services.AddTransient<AnswerRepo>();

            services.AddRazorPages();
        }

 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
