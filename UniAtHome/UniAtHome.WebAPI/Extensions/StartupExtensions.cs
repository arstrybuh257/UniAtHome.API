using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Interfaces.Collection;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.BLL.Interfaces.Zoom;
using UniAtHome.BLL.Services;
using UniAtHome.BLL.Services.Collection;
using UniAtHome.BLL.Services.Test;
using UniAtHome.BLL.Services.Zoom;
using UniAtHome.DAL;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Entities.Tests;
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
            services.AddScoped<UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IRepository<UniversityAdmin>, Repository<UniversityAdmin>>();
            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IRepository<UniversityCreateRequest>, Repository<UniversityCreateRequest>>();
            services.AddScoped<IRepository<ZoomUser>, Repository<ZoomUser>>();
            services.AddScoped<IRepository<ZoomMeeting>, Repository<ZoomMeeting>>();
            services.AddScoped<IRepository<Test>, Repository<Test>>();
            services.AddScoped<IRepository<TestQuestion>, Repository<TestQuestion>>();
            services.AddScoped<IRepository<TestAnswerVariant>, Repository<TestAnswerVariant>>();
            services.AddScoped<IRepository<TestSchedule>, Repository<TestSchedule>>();
            services.AddScoped<IRepository<TestAttempt>, Repository<TestAttempt>>();
            services.AddScoped<IRepository<TestAnsweredQuestion>, Repository<TestAnsweredQuestion>>();

            services.AddSingleton<IRefreshTokenFactory, RefreshTokenFactory>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IPasswordGenerator, PasswordGenerator>();

            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddScoped<IUniversityRequestService, UniversityRequestService>();
            services.AddScoped<IUniversityRegistrationService, UniversityRegistrationService>();
            services.AddScoped<ITimetableService, TimetableService>();
            services.AddScoped<ICollectionShuffler, RandomCollectionShuffler>();

            services.AddScoped<ITestCreationService, TestCreationService>();
            services.AddScoped<ITestQuestionCreationService, TestQuestionCreationService>();
            services.AddScoped<ITestAnswerCreationService, TestAnswerCreationService>();
            services.AddScoped<ITestSchedulingService, TestSchedulingService>();
            services.AddScoped<ITestGenerationService, TestGenerationService>();
            services.AddScoped<ITestCreationService, TestCreationService>();
            services.AddScoped<ITestTakingService, TestTakingService>();
            services.AddScoped<ITestFullInfoService, TestFullInfoService>();

            services.AddScoped<ZoomAdminClient>();
            services.AddScoped<IZoomAuthService, ZoomAuthService>();
            services.AddScoped(services => new Lazy<IZoomAuthService>(services.GetService<IZoomAuthService>));
            services.AddScoped<ZoomMeetingService>();

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
