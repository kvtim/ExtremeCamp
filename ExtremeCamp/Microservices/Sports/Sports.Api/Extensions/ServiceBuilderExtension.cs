using Microsoft.EntityFrameworkCore;
using Sports.Core.Repositories;
using Sports.Data;
using Sports.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Api.Extensions
{
    public static class ServiceBuilderExtension
    {
        public static void ConfigureServices(
        this IServiceCollection services,
         ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Program));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISportRepository, SportRepository>();

            services.AddMediatrWithConfiguration();

            services.AddControllersWithJsonConfiguration();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.ConfigureSwagger();
        }
    }
}
