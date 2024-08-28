using API.RabbitMQ.MassTransit.Consumers;
using API.RabbitMQ.MassTransit.Interfaces;
using API.RabbitMQ.MassTransit.Providers;
using MassTransit;

namespace API.RabbitMQ.MassTransit.Extensions
{
    public static class AppExtension
    {        

        public static void Injections(this IServiceCollection services)
        {
            services.AddTransient<IPublishBus, PublishBus>();
        }

        public static void AddRabbitMQService(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                //Adicionei o consumer, para add uma exchange do tipo fanout e uma fila para essa exchange
                busConfigurator.AddConsumer<RelatorioSolicitadoEventConsumer>();

                //Configuracão do RabbitMQ com o MassTransit
                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    //Configurar o Host
                    configurator.Host(new Uri(SettingsProvider.GetHostRabbitMQ()), host =>
                    {
                        host.Username(SettingsProvider.GetUsernameRabbitMQ());
                        host.Password(SettingsProvider.GetPasswordRabbitMQ());
                    });

                    //Aplicar as configuracoes ao contexto
                    configurator.ConfigureEndpoints(context);
                });
            });
        }
    }
}
