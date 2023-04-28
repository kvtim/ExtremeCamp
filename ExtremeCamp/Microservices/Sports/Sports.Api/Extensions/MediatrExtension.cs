using Sports.Data.Sports.Commands.CreateSport;

namespace Sports.Api.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatrWithConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSportCommand).Assembly));
        }
    }
}
