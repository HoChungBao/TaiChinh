using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using TaiChinh.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaiChinh.Core.Interface;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Serviece;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Food.Core.Entities;
using Data.Core.Data;
using Food.Core.Interfaces;
using Food.Core.Services;
using Data.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AccountModule.Models.AccountViewModels;
using GoldModule.Extensions;
using Gold.Core.Entities;

namespace TaiChinh
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
            services.AddDbContext<TaiChinhContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TaiChinhConnection")));

            services.AddDbContext<FoodContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("FoodConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(
                 Configuration.GetConnectionString("TaiChinhConnection")));

            services.AddDbContext<GoldContext>(options =>
                  options.UseSqlServer(
                 Configuration.GetConnectionString("GoldConnection")));

            services.AddIdentityCore<ApplicationUser>()
                  .AddRoles<IdentityRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddSignInManager()
                  .AddDefaultTokenProviders();

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });


            //[Authorize(AuthenticationSchemes = AuthSchemes)]
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Unauthorized/";
                        options.AccessDeniedPath = "/Account/Forbidden/";
                    })
                    .AddJwtBearer(options =>
                    {
                        options.Audience = "http://localhost:5001/";
                        options.Authority = "http://localhost:5000/";
                        options.RequireHttpsMetadata = false;
                    });

            //[Authorize(Policy = "Over18")]
            //
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    //policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.AuthenticationSchemes.Add(IdentityConstants.ApplicationScheme);
                    policy.RequireAuthenticatedUser();
                    //policy.Requirements.Add(new MinimumAgeRequirement());
                });
            });

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddMvc();  
            services.AddRazorPages();

            //Service

            //Finace
            services.AddScoped<ITaiKhoanService, TaiKhoanService>();
            services.AddScoped<IChiService, ChiService>();
            services.AddScoped<IThuService, ThuService>();
            services.AddScoped<ITyLeService, TyLeService>();

            //Food
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IVegetableService, VegetableService>();
            services.AddScoped(typeof(ISlugService<,>), typeof(SlugService<,>));

            //Gold
            services.AddServicesGold();

            //Reponsitory
            services.AddScoped(typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));

            services.AddOrchardCore()
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=DashBoard}/{action=Index}/{id?}");
            });

            app.UseOrchardCore();
        }
    }
}
