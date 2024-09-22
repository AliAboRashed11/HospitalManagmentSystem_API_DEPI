
using HospitalManagmentSystem.API.Middleware;
using HospitalManagmentSystem.BLL.AutoMapper;
using HospitalManagmentSystem.BLL.Manager;
using HospitalManagmentSystem.BLL.Manager.Accounts;
using HospitalManagmentSystem.DAL.Data.DbHelper;
using HospitalManagmentSystem.DAL.Data.Models;
using HospitalManagmentSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HospitalManagmentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HospitalSytemContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JWT";
                options.DefaultChallengeScheme = "JWT";

            }).AddJwtBearer("JWT", options =>
            {
                #region SecretKey
                var SecretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var SecretKeyBytes = Encoding.ASCII.GetBytes(SecretKeyString);
                SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyBytes);
                #endregion

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,
                    ValidateIssuer=false,
                    ValidateAudience=false,
                };
            });


            builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric =false;
                options.Password.RequireLowercase =false;
                options.Password.RequireUppercase =false;
                options.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<HospitalSytemContext>();

            builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));

            builder.Services.AddScoped<IAccountManager , AcountManager>();
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IDoctorManager, DoctorManager>();
            //builder.Services.AddScoped<IDoctorManager, DoctorAutoMapperManager>();
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<FirstMiddelware>();

            app.UseMiddleware<SecondMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                await next.Invoke(context);
            });

            app.MapControllers();

            app.Run();
        }
    }
}