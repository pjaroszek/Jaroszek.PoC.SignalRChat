namespace Jaroszek.PoC.SignalRChat.WebUI.Hubs
{
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Events;

    public interface IChatClient
    {
        Task ReceiveMessage(SentMessage notification);
    }
}