using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Services;
using UniAtHome.DAL;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;
using UniAtHome.WebAPI.Configuration;

namespace UniAtHome.WebAPI.Extensions
{

    public static class StartupExtensions
    {
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenProvider = new JwtTokenGenerator(configuration);
            services
                .AddSingleton<IAuthTokenGenerator>(tokenProvider)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    authenticationScheme: JwtBearerDefaults.AuthenticationScheme,
                    configureOptions: options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = tokenProvider.TokenValidationParameters;
                    });
            return services;
        }

        public static IServiceCollection RegisterIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IRepository<UniversityAdmin>, Repository<UniversityAdmin>>();
            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<IRepository<Group>, GroupRepository>();

            services.AddSingleton<IRefreshTokenFactory, RefreshTokenFactory>();

            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IUniversityService, UniversityService>();

            services.AddScoped<DbContext, UniAtHomeDbContext>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
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
