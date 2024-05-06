using LibraryManagementSystem.Repository;
using LibraryManagementSystem.Repository.Repository;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Caching.Memory;
using LybraryManagementSystem.Application.Helper;
using LybraryManagementSystem.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Mappings.Interface;
using LybraryManagementSystem.Application.Mappings;

namespace LybraryManagementSystem.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddScoped<IBookInstanceRepository, BookInstanceRepository>();
            builder.Services.AddScoped<IBookInstanceService, BookInstanceService>();

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();

            builder.Services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
            builder.Services.AddScoped<IAuthorBookService, AuthorBookService>();

            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddScoped<IPasswordResetRepository, PasswordResetRepository>();
            builder.Services.AddScoped<IPasswordResetService, PasswordResetService>();

            builder.Services.AddScoped<IIdentityService, IdentityService>();

            //builder.Services.AddScoped<INotificationMapping, NotificationMapping>();

            builder.Services.AddScoped<ICacheService, CacheService>();

            var emailConfig = builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
            builder.Services.AddSingleton(emailConfig);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                //options.JsonSerializerOptions.Converters.Add(new CustomJsonConverterForType());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    //ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            //builder.Services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = builder.Configuration[""];
            //    options.InstanceName = "";
            //});


            builder.Services.AddMemoryCache(cache =>
            {
                cache.SizeLimit = 1024;
                cache.ExpirationScanFrequency = TimeSpan.FromSeconds(60);
                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //   .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                //   .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                //   .SetPriority(CacheItemPriority.Normal)
                //   .SetSize(1024);

            });

            var connectionString = builder.Configuration.GetConnectionString("LibraryManagementSystem");
            builder.Services.AddDbContext<LibraryDbContext>(x => x.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}