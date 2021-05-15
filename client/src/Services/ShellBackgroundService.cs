namespace Jaroszek.PoC.SignalRChat.Client.Services
{
    using Jaroszek.PoC.SignalRChat.Client.Events;
    using Jaroszek.PoC.SignalRChat.Client.Interfaces;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    using Prism.Events;

    using System;

    public sealed partial class ShellBackgroundService : IBackgroundService
    {
        private readonly ILogger<ShellBackgroundService> logger;
        private readonly IEventAggregator eventAggregator;
        private volatile bool disposed;

        private readonly SubscriptionToken connectedToken;
        private readonly SubscriptionToken disconnectedToken;
        private readonly SubscriptionToken sendMessageToken;

        HubConnection connection;
        private const string URL = "https://localhost:5001/chatHub/";

        public ShellBackgroundService(IEventAggregator eventAggregator, ILoggerFactory loggeFactory)
        {
            this.eventAggregator = eventAggregator;
            this.logger = loggeFactory.CreateLogger<ShellBackgroundService>();

            this.logger.LogInformation("created instance ShellBackgroundService");


            this.connectedToken = this.eventAggregator.GetEvent<ConnectToSignalRClientEvent>()
               .Subscribe(this.ConnectToSignalRServer, ThreadOption.UIThread);

            this.disconnectedToken = this.eventAggregator.GetEvent<DisconnectSignalRServerRequestEvent>().Subscribe(this.Disconnect, ThreadOption.UIThread);

            this.sendMessageToken = this.eventAggregator.GetEvent<SendMessageSignalRServerRequestEvent>()
                .Subscribe(this.SendNotification, ThreadOption.UIThread);

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
                this.eventAggregator.GetEvent<ConnectToSignalRClientEvent>().Unsubscribe(connectedToken);
                this.logger.LogInformation("dispose instance ShellBackgroundService");
            }

            this.disposed = true;
        }
    }
}