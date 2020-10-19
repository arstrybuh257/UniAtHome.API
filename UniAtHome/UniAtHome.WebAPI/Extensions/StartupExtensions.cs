using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
    }
}
