using System;
using kanban_backed.Business.Configuration;
using kanban_backed.Business.Interfaces;
using kanban_backed.Business.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using kanban_backed.Infra.Repositories;
using kanban_backed.Infra;
using Microsoft.EntityFrameworkCore;
using kanban_backed.Bs.Interfaces;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.VisualBasic;

namespace kanban_backend.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        { 
            services
            .AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<ApiContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("MyDatabase");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddLogging(logging =>
            {
                logging.AddConsole(); 
                logging.AddFilter<EventLogLoggerProvider>("Microsoft", LogLevel.Warning);
            });

            // repositories

            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            // services
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }

        public static IServiceCollection AddAppAuthentication(this IServiceCollection services, JwtSettings authSettings)
        {
            services.AddAuthorization();
            services.AddAuthentication("Bearer").AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authSettings.Issuer,
                    ValidAudience = authSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }
    }
}

