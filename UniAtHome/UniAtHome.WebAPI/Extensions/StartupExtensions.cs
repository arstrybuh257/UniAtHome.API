using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;
using UniAtHome.DAL;
using UniAtHome.DAL.Entities;

namespace UniAtHome.WebAPI.Extensions
{
    public sealed class AuthTokenValidationOptions : TokenValidationParameters
    {
        public int LifetimeMinutes => 60;

        public AuthTokenValidationOptions()
        {
            ValidateIssuer = true;
            ValidIssuer = "UniAtHomeBackEnd";

            ValidateAudience = true;
            ValidAudience = "UniAtHomeFrontEnd";

            ValidateLifetime = true;

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GetSecretKey()));
            ValidateIssuerSigningKey = true;
        }

        private static string GetSecretKey()
        {
            return "here must be really strong secret key";
        }
    }

    public static class StartupExtensions
    {
        public static IServiceCollection RegisterIoC(this IServiceCollection services)
        {
            //Please, configure all required dependencies here (repositories, services)
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // TODO: change to true when in production mode
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new AuthTokenValidationOptions();
                });

            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(
                    config =>
                    {
                        config.User.RequireUniqueEmail = true;
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
