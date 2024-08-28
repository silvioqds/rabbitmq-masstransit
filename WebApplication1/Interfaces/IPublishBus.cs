namespace API.RabbitMQ.MassTransit.Interfaces
{
    public interface IPublishBus
    {
        Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    }
}
