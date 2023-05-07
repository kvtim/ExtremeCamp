using EventBus.Messages.Common;
using Users.Api.EventBusConsumer;
using MassTransit;

namespace Users.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static void ConfigureMassTransit(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddMassTransit(config =>
            {
                config.AddConsumer<GetUserByUserNameConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.GetUserByUsername, c => {
                        c.ConfigureConsumer<GetUserByUserNameConsumer>(ctx);
                    });
                });
            });
        }
    }
}
