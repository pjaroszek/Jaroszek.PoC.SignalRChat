namespace Jaroszek.PoC.SignalRChat.WebUI.Hubs
{
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Events;
    using Microsoft.AspNetCore.SignalR;

    public sealed class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var notification = new SentMessage
            {
                Message = message,
                UserName = user,
            };
            await Clients.All.SendAsync("ReceiveMessage", notification);
        }
    }
}