namespace Jaroszek.PoC.SignalRChat.Client.ViewModels
{
    using Jaroszek.PoC.SignalRChat.Client.Events;

    using Prism.Commands;

    using System.Windows.Input;

    public sealed partial class ShellViewModel
    {
        public ICommand WindowLoadedCommand => new DelegateCommand(() =>
       {
           this.eventAgregator.GetEvent<ConnectToSignalRClientEvent>().Publish();
           this.Status = "Ready";

       });

        public ICommand WindowClosedCommand => new DelegateCommand(() =>
        {
            Properties.Settings.Default.Save();
            this.eventAgregator.GetEvent<DisconnectSignalRServerRequestEvent>().Publish();
            this.Status = "Disconnected";
            this.Dispose();
        });
    }
}
