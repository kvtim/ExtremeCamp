using Meetups.Data.Meetups.Commands.CreateMeetup;

namespace Meetups.Api.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatrWithConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMeetupCommand).Assembly));
        }
    }
}
