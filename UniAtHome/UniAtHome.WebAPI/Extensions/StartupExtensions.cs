using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UniAtHome.DAL;
using UniAtHome.DAL.Entities;

namespace UniAtHome.WebAPI.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterIoC(this IServiceCollection services)
        {
            //Please, configure all required dependencies here (repositories, services)
            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(
                    config =>
                    {
                        //Please, add identity configuration here
                    })
                .AddEntityFrameworkStores<UniAtHomeDbContext>();
            return services;
        }
    }
}
