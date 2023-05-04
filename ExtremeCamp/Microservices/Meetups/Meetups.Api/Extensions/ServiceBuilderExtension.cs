using Microsoft.EntityFrameworkCore;
using Meetups.Core.Repositories;
using Meetups.Data;
using Meetups.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Api.Extensions
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
            services.AddScoped<IMeetupRepository, MeetupRepository>();

            services.AddMediatrWithConfiguration();

            services.AddControllersWithJsonConfiguration();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.ConfigureSwagger();
        }
    }
}
