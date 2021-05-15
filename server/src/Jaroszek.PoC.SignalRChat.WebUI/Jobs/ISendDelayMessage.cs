namespace Jaroszek.PoC.SignalRChat.WebUI.Jobs
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Hangfire;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Commands;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Queries;

    public interface ISendDelayMessage
    {
        [DisplayName("Send delay \"{1}\" message to {0}.")]
        [AutomaticRetry(Attempts = 0)]
        Task Run(string userName, string message);

        [DisplayName("Send by user \"{1}\" message to {0}.")]
        [AutomaticRetry(Attempts = 0)]
        Task Run(SendMessage command);


        [DisplayName("Send message to {0}.")]
        [AutomaticRetry(Attempts = 0)]
        Task Run(ReadMessage id);
    }
}
