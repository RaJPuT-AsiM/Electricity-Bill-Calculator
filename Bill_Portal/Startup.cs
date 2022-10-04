using Bill_Portal.Helpers;
using Bill_Portal.Models;
using Bill_Portal.Repository;
using Bill_Portal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bill_Portal
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
            //claims
            services.AddScoped<IUserClaimsPrincipalFactory<BillUsers>, BillUserClaimsPricipalFactory>();
            //userservice
            services.AddScoped<IUserService, UserService>();
            services.AddControllersWithViews();
            
            
            var connection = "Server = DESKTOP-QG3ILAS\\SQLEXPRESS; Database = Billing_Portal_Db; Trusted_Connection = True; MultipleActiveResultSets=true;";
            services.AddDbContext<Billing_Portal_DbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<Billing_Portal_Db_CRUD_Context>(options => options.UseSqlServer(connection));
            services.AddIdentity<BillUsers, IdentityRole>()
                .AddEntityFrameworkStores<Billing_Portal_DbContext>();
            
            services.AddScoped<IAccountRepository, AccountRepository>();
            
            //Configure Password
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            });
            // configure unauthorized access to login page
            services.ConfigureApplicationCookie(config =>
                {
                    config.LoginPath = "/Account/SignInUser";
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //   pattern: "{controller=Roles}/{action=CreateRole}/{id?}");
            });
        }
    }
}
