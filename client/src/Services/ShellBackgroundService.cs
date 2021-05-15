namespace Jaroszek.PoC.SignalRChat.Client.Services
{
    using Jaroszek.PoC.SignalRChat.Client.Interfaces;

    using Microsoft.Extensions.Logging;

    using Prism.Events;

    using System;

    public sealed partial class ShellBackgroundService : IBackgroundService
    {
        private readonly ILogger<ShellBackgroundService> logger;
        private readonly IEventAggregator eventAggregator;
        private volatile bool disposed;

        public ShellBackgroundService(IEventAggregator eventAggregator, ILoggerFactory loggeFactory)
        {
            this.eventAggregator = eventAggregator;
            this.logger = loggeFactory.CreateLogger<ShellBackgroundService>();
        }

        ~ShellBackgroundService()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                //  this.timer.Stop();

                this.logger.LogInformation("dispose instance ShellBackgroundService");
            }

            this.disposed = true;
        }
    }
}