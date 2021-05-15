namespace Jaroszek.PoC.SignalRChat.Client.Services
{
    using Jaroszek.PoC.SignalRChat.Client.Events;
    using Jaroszek.PoC.SignalRChat.Client.Models;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    using System;

    public sealed partial class ShellBackgroundService
    {
        private void ConnectToSignalRServer()
        {
            this.logger.LogInformation("Start connect to SignalR server from WPF");
            try
            {
                connection = new HubConnectionBuilder().WithUrl(URL).Build();
                connection.On<ChatMessage>("ReceiveMessage", message =>

              {
                  this.eventAggregator.GetEvent<ReceivedMessageSignalRResponse>().Publish(message);


              });
                connection.StartAsync();
                this.eventAggregator.GetEvent<ChangeStatusRequestEvent>().Publish("Connected");
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, exception.Message);
                throw;
            }

        }

        private void SendNotification(string notification)
        {

            var message = new ChatMessage()
            {
                Message = notification,
                UserName = "WPF"
            };

            connection.SendAsync("SendMessage", "SendAsync");
            connection.InvokeAsync("SendMessage", "InvokeAsync");
            connection.InvokeCoreAsync("SendMessage", new object[] { message.UserName, message.Message });


        }

        private void Disconnect()
        {
            if (connection != null)
            {
                connection.StopAsync();
                this.eventAggregator.GetEvent<ChangeStatusRequestEvent>().Publish("Disconnect");
            }


        }
    }
}
