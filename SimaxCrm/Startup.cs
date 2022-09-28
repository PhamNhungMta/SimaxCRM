using DNTCaptcha.Core;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using SimaxCrm.Data.Context;
using SimaxCrm.Helper;
using SimaxCrm.Hubs;
using SimaxCrm.Model.Entity;
using SimaxCrm.Registry;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace SimaxCrm
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly("SimaxCrm.Data")));
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactory>();
            services.AddLamar(new ApplicationRegistry());

            services.AddControllersWithViews().AddRazorPagesOptions(options =>
            {
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAuthentication()
                .AddCookie()
               .AddJwtBearer(x =>
               {
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MyJwtSceuritySmartCrewToken")),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });



           
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(2);
                
            });

            services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);

            services.AddSignalR();

            services.AddRazorPages();

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddDNTCaptcha(options =>
            {
               options.UseCookieStorageProvider(SameSiteMode.Strict) // -> It relies on the server and client's times. It's ideal for scalability, because it doesn't save anything in the server's memory.
                                                                      // .UseDistributedCacheStorageProvider() // --> It's ideal for scalability using `services.AddStackExchangeRedisCache()` for instance.
                                                                      // .UseDistributedSerializationProvider()

                // Don't set this line (remove it) to use the installed system's fonts (FontName = "Tahoma").
                // Or if you want to use a custom font, make sure that font is present in the wwwroot/fonts folder and also use a good and complete font!
                //.UseCustomFont(Path.Combine(_env.WebRootPath, "fonts", "IRANSans(FaNum)_Bold.ttf")) // This is optional.
                .AbsoluteExpiration(minutes: 7)
                .ShowThousandsSeparators(false)
                .WithNoise(pixelsDensity: 25, linesCount: 3)
                .WithEncryptionKey("This is my secure key!")
                .InputNames(// This is optional. Change it if you don't like the default names.
                    new DNTCaptchaComponent
                    {
                        CaptchaHiddenInputName = "DNTCaptchaText",
                        CaptchaHiddenTokenName = "DNTCaptchaToken",
                        CaptchaInputName = "DNTCaptchaInputText"
                    })
                .Identifier("dntCaptcha")// This is optional. Change it if you don't like its default name.
                ;
            });

            services.AddSwaggerGen();

        }

        private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            options.Path = "/";
            // options.Secure = true;
            // options.SameSite = SameSiteMode.None;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                // MinimumSameSitePolicy = SameSiteMode.None,
                // Secure = CookieSecurePolicy.Always,
                OnAppendCookie = cookieContext =>
                 CheckSameSite(cookieContext.Context, cookieContext.CookieOptions)
            };

            app.UseCookiePolicy(cookiePolicyOptions);



            app.UseAuthentication();
            app.UseAuthorization();


            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger.json", "My Test1 Api v1");
            });

            app.Use(async (context, next) =>
            {
               
                context.Response.Headers.Add("X-Frame-Options", "ALLOWALL");
                await next();
            });



            app.UseEndpoints(endpoints =>
            {
                RouteProvider.AdminEndpointMapping(endpoints);
                RouteProvider.MainEndpointMapping(endpoints);
                endpoints.MapGet("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.Redirect("/Account/Register", true, true)));
                endpoints.MapPost("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.Redirect("/Account/Register", true, true)));
                endpoints.MapGet("/Identity/Account/Login", context => Task.Factory.StartNew(() => context.Response.Redirect("/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/Login", context => Task.Factory.StartNew(() => context.Response.Redirect("/Account/Login", true, true)));
            });

           
        }
    }
}
