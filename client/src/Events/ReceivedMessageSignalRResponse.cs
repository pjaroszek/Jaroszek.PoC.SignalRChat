namespace Jaroszek.PoC.SignalRChat.Client.Events
{
    using Jaroszek.PoC.SignalRChat.Client.Models;

    using Prism.Events;

    public sealed class ReceivedMessageSignalRResponse : PubSubEvent<ChatMessage>
    {

    }
}
