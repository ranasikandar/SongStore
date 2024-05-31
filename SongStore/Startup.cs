using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SongStore.DAL;
using SongStore.Models;
using System;

namespace SongStore
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            };

            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            ;

            services.Configure<DataProtectionTokenProviderOptions>(o =>
                        o.TokenLifespan = TimeSpan.FromHours(24));

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddXmlSerializerFormatters();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = new PathString("/Account/Login");
                options.LogoutPath = "/Account/Logout";
                
                options.Cookie.HttpOnly = true;

                options.Cookie.Name = "UserIdentity";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = "X_CSRF_TOKEN_SongStoreAUTH";
                options.FormFieldName = "CSRF_TOKEN_SongStoreAUTH_FORM5";
            });

            services.Configure<CookieTempDataProviderOptions>(opt => opt.Cookie.Name = "TempDataProvider");

            services.AddScoped<IDBRepo, DBRepo>();

            //services.AddTransient<IEmailService, EmailService>();
            //services.AddTransient<Utilities.Helper>();
            //services.AddTransient<ISmsSender, MessageSender>();
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

            app.UseCookiePolicy();
            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.EnableDirectoryBrowsing = false;
            app.UseFileServer(fileServerOptions);

            app.UseRouting();

            app.UseAuthentication();
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
