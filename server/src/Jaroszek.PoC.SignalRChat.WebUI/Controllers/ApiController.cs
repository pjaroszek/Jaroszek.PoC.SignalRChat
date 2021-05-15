namespace Jaroszek.PoC.SignalRChat.WebUI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Hangfire;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Commands;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Queries;
    using Jaroszek.PoC.SignalRChat.WebUI.Jobs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public sealed class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> logger;
        private readonly IMediator mediator;
        public ApiController(ILogger<ApiController> logger, IMediator mediator) =>
            (this.logger, this.mediator) = (logger, mediator);

        [HttpPost]
        public async Task<IActionResult> Post(SendMessage command)
        {
            this.logger.LogInformation("{Command}", command);
            // _ = this.mediator.Send(command);
            BackgroundJob.Enqueue<ISendDelayMessage>(x => x.Run(command));
            return await Task.FromResult(Ok());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            BackgroundJob.Enqueue<ISendDelayMessage>(x => x.Run("Hangfire", "Pi Pi Pi"));
            return await Task.FromResult(Ok());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            BackgroundJob.Enqueue<ISendDelayMessage>(x => x.Run(new ReadMessage { MessageId = id }));
            return await Task.FromResult(Ok());
        }
    }
}
