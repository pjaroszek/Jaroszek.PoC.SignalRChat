namespace Jaroszek.PoC.SignalRChat.Client.ViewModels
{
    using Jaroszek.PoC.SignalRChat.Client.Events;

    using Prism.Commands;

    using System;
    using System.Windows.Input;

    public sealed partial class ShellViewModel
    {
        public ICommand SendMessageCommand => new DelegateCommand(() =>
        {
            if (!string.IsNullOrEmpty(Message))
            {
                this.eventAgregator.GetEvent<SendMessageSignalRServerRequestEvent>().Publish(Message);
                this.Message = String.Empty;
            }

        });

        public ICommand DisconnectCommand => new DelegateCommand(
            () =>
            {
                this.eventAgregator.GetEvent<DisconnectSignalRServerRequestEvent>().Publish();
            });
        public ICommand ConnectCommand => new DelegateCommand(() =>
         {
             this.eventAgregator.GetEvent<ConnectToSignalRClientEvent>().Publish();
         });

    }
}
