using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniAtHome.DAL;
using UniAtHome.DAL.Entities;

namespace UniAtHome.WebAPI.Extensions
{
    public sealed class AuthTokenValidationOptions : TokenValidationParameters
    {
        private IConfiguration configuration;

        public int LifetimeMinutes { get; set; }

        public AuthTokenValidationOptions(IConfiguration configuration)
        {
            this.configuration = configuration;
            var fromAppsettings = GetAuthTokenSettings();

            ValidateLifetime = fromAppsettings.ValidateLifetime;
            this.LifetimeMinutes = fromAppsettings.TokenLifetimeMinutes;

            ValidateIssuer = true;
            ValidIssuer = fromAppsettings.ValidIssuer;

            ValidateAudience = true;
            ValidAudience = fromAppsettings.ValidAudience;

            ValidateIssuerSigningKey = true;
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(fromAppsettings.SigningKey));
        }

        private AuthTokenSettings GetAuthTokenSettings()
        {
            var tokenOptionsFromAppsettings = new AuthTokenSettings();
            configuration.Bind("AuthenticationToken", tokenOptionsFromAppsettings);
            return tokenOptionsFromAppsettings;
        }

        private class AuthTokenSettings
        {
            public string ValidIssuer { get; set; }

            public string ValidAudience { get; set; }

            public string SigningKey { get; set; }

            public bool ValidateLifetime { get; set; }

            public int TokenLifetimeMinutes { get; set; }
        }
    }

    public static class StartupExtensions
    {

        // TODO: i'll use it
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = true;
            //        options.TokenValidationParameters = new AuthTokenValidationOptions(configuration);
            //    });
            return services;
        }

        public static IServiceCollection RegisterIoC(this IServiceCollection services)
        {
            
            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new AuthTokenValidationOptions(Configuration); // <---- try to get it
            });

            services.AddIdentity<User, IdentityRole>(
                    config =>
                    {
                        // Our UserNames = Emails. When registering new user with already registered email
                        // there will be two unique violations unless emails ain't requiered to be unique.
                        config.User.RequireUniqueEmail = false;
                        config.Password.RequireNonAlphanumeric = false;
                        config.Password.RequireDigit = true;
                    })
                .AddEntityFrameworkStores<UniAtHomeDbContext>();
            return services;
        }

        public static IServiceCollection SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "UniAtHome.API", Version = "v1" });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme."
                    });

                    var securityScheme = new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    };
                    var requirements = new OpenApiSecurityRequirement
                    {
                        {securityScheme, new List<string>()}
                    };
                    options.AddSecurityRequirement(requirements);
                }
            );
            return services;
        }
    }
}
