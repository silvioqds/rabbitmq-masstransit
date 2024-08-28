using API.RabbitMQ.MassTransit.Interfaces;
using MassTransit;

namespace API.RabbitMQ.MassTransit
{
    public class PublishBus : IPublishBus
    {
        private readonly IBus _bus;

        public PublishBus(IBus bus)
        {
            _bus = bus;
        }

        public Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
        {
            return _bus.Publish(message, cancellationToken);
        }
    }
}
