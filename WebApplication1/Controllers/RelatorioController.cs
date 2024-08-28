using API.RabbitMQ.MassTransit.Interfaces;
using API.RabbitMQ.MassTransit.Model;
using API.RabbitMQ.MassTransit.Relatorios;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace API.RabbitMQ.MassTransit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {                
        
        public RelatorioController() { } 


        [HttpPost("/solicitar-relatorio")]
        public async Task<IResult> SolicitarRelatorio(string name, IPublishBus bus, CancellationToken cancellationToken = default)
        {
            var solicitacao = new SolicitacaoRelatorio()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Status = "Pendente",
                ProcessedTime = null
            };

            //Salvando na memória para simular um banco
            Lista.Relatorios.Add(solicitacao);

            var eventRequest = new RelatorioSolicitadoEvent(solicitacao.Id, solicitacao.Name);

            await bus.PublishAsync(eventRequest, cancellationToken);

            return Results.Ok(solicitacao);
        }

        [HttpGet("/relatorios")]
        public async Task<List<SolicitacaoRelatorio>> GetRelatorios()
        {
            return await Task.FromResult(Lista.Relatorios);
        }

    }
}
