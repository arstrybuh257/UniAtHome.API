using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniAtHome.BLL.Options;
using UniAtHome.DAL;
using UniAtHome.WebAPI.Extensions;
using UniAtHome.WebAPI.Middleware;

namespace UniAtHome.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UniAtHomeDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DbContext, UniAtHomeDbContext>();

            services.AddCors();
            services.AddIdentityConfiguration();
            services.RegisterIoC();

            services.AddJwtTokenAuthentication(Configuration);

            services.Configure<StorageServiceConfig>(Configuration.GetSection("StorageService"));
            services.Configure<ZoomClientConfig>(Configuration.GetSection("Zoom"));

            services.SwaggerConfiguration();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var corsUrls = new List<string>();
            Configuration.GetSection("AllowedHosts").Bind(corsUrls);
            app.UseCors(builder => builder.WithOrigins(corsUrls.ToArray())
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.Migrate();
        }
    }
}
