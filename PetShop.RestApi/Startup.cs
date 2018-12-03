using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;
using TodoApi.Helpers;

namespace PetShop.RestApi
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfiguration _conf { get; }
        private readonly ILogger _logger;

        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            if (_env.IsDevelopment() || _env.IsProduction())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlite("Data Source=petApp.db"));
            }
            else
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }
    
            _logger.LogInformation("Added TodoRepository to services");
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                _logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    DBInitializer.SeedDB(ctx);
                }
                app.UseHsts();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
