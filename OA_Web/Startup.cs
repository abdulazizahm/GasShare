using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OA_DAL.Models;
using OA_Repository.Bases;
using OA_Repository.Identity;
using OA_Repository.Interfaces;
using OA_Service.AppServices;
using OA_Service.Bases;
using OA_Service.Interfaces;
using OA_Service.Repositories;
using OA_Service.Settings;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web
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
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("GSCS"),
                b => b.MigrationsAssembly("OA_Repository")
            ));




            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddTransient<IMailService, MailService>();
            //services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CarAppService, CarAppService>();
            //Add by ibrahim
            services.AddScoped<UserPhotoAppService, UserPhotoAppService>();
            services.AddScoped<UserRateAppService, UserRateAppService>();
            services.AddScoped<AccountAppService, AccountAppService>();
            services.AddScoped<CommentAppService, CommentAppService>();
            services.AddScoped<NotificationAppService, NotificationAppService>();
            services.AddScoped<RoleAppService, RoleAppService>();
            services.AddScoped<BaseAppService<ApplicationUser>, AccountAppService>();
            services.AddScoped<JourneyAppService, JourneyAppService>();
            services.AddScoped<RequestAppService, RequestAppService>();
            services.AddScoped<RequestPhotoAppService, RequestPhotoAppService>();
            services.AddScoped<ComplainAppService, ComplainAppService>();
            services.AddScoped<JourneyRateAppService, JourneyRateAppService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsActive", policy =>
                    policy.AddRequirements(new IsActiveRequirement()));
            });

            services.AddScoped<IAuthorizationHandler, IsActiveHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
