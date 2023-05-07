using Users.Data;
using Users.Data.Repositories;
using Users.Data.UnitOfWork;
using Users.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Core.Repositories;
using Users.Core.Security;
using Users.Core.Services;
using Users.Core.UnitOfWork;
using Users.Api.EventBusConsumer;

namespace Users.Api.Extensions
{
    public static class ServiceBuilderExtension
    {
        public static void ConfigureServices(
            this IServiceCollection services,
             ConfigurationManager configuration)
        {
            services.AddJWTAuthentication(configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Program));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IHasher, Hasher>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJWTTokenService, JWTTokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRegistrationService, RegistrationService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithJsonConfiguration();

            services.AddEndpointsApiExplorer();

            services.ConfigureMassTransit(configuration);

            services.AddScoped<GetUserByUserNameConsumer>();

            services.ConfigureSwagger();
        }
    }
}
