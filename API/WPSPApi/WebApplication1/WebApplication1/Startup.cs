using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;  // ?
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WPSPApi.DataProvider;
using WPSPApi.JWTSecurity;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //public HttpConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // added 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = "Fiver.Security.Bearer",
                            ValidAudience = "Fiver.Security.Bearer",
                            IssuerSigningKey = JwtSecurityKey.Create("fiver-secret-key")
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member",
                    policy => policy.RequireClaim("MembershipId"));
            });
            
            // -- added sample code
            //// added for CORS suppor 
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAllHeaders",
            //          builder =>
            //          {
            //              builder.AllowAnyOrigin()
            //                     .AllowAnyHeader()
            //                     .AllowAnyMethod();
            //          });
            //});
            //// July 6 2018
            // --- end sample code

            // original 
            services.AddTransient<IPatrollerDataProvider, PatrollerDataProvider>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // -- added sample code
            ////string origin = "http://localhost:63635/";
            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "GET,POST");

            //HttpConfiguration config = Configuration as HttpConfiguration;
            //config.EnableCors(cors);
            // --- end sample code
            
            // added for Cors support
            // Shows UseCors with named policy.
            app.UseCors("AllowAllHeaders");

            // added
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();

            // original
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            // -- original 


            


        }
    }
}


// additional notes and sources:
// -----------------------------------
// see this for the sample walkthrough for the app scaffolding
// https://medium.com/@maheshi.gunarathne1994/web-api-using-asp-net-core-2-0-and-entity-framework-core-with-mssql-59d30f33ff64 

// this is the example for the token
// https://www.c-sharpcorner.com/article/asp-net-core-2-0-bearer-authentication/

// must have .NET Core SDK installed to run on port 80 in IIS
// https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-2.1&tabs=aspnetcore2x
// https://wildermuth.com/2017/07/06/Program-cs-in-ASP-NET-Core-2-0

// other .NET Core config links
// https://andrewlock.net/configuring-urls-with-kestrel-iis-and-iis-express-with-asp-net-core/
// https://stackify.com/how-to-deploy-asp-net-core-to-iis/
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-2.1&tabs=aspnetcore2x
// 

// deploy angular
// https://blog.angularindepth.com/deploy-an-angular-application-to-iis-60a0897742e7
