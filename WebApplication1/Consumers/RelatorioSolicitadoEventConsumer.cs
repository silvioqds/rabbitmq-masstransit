using API.RabbitMQ.MassTransit.Model;
using API.RabbitMQ.MassTransit.Relatorios;
using MassTransit;

namespace API.RabbitMQ.MassTransit.Consumers
{
    public class RelatorioSolicitadoEventConsumer : IConsumer<RelatorioSolicitadoEvent>
    {
        private readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;

        public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
        {
            _logger.LogInformation($"Processando Relatório ID: {context.Message.Id} Nome: {context.Message.Name}");

            await Task.Delay(10000);

            var relatorio = Lista.Relatorios.FirstOrDefault(x=> x.Id == context.Message.Id);

            if(relatorio != null)
            {
                relatorio.Status = "Processado";
                relatorio.ProcessedTime = DateTime.Now;
            }

            _logger.LogInformation($"Relatório Processado ID: {context.Message.Id} Nome: {context.Message.Name}");
        }
    }
}
