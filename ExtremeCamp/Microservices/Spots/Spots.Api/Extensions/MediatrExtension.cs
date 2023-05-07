using Spots.Data.Spots.Commands.CreateSpot;

namespace Spots.Api.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatrWithConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSpotCommand).Assembly));
        }
    }
}
