namespace Jaroszek.PoC.SignalRChat.Client.ViewModels
{
    using System.Collections.ObjectModel;

    public sealed partial class ShellViewModel
    {
        private string status = "Disconnected";
        private string title = "SignalR Client";
        private string message;
        private bool isVisibilityConnected = true;
        private bool isConnectToSignalR = false;
        private bool isDisconnectToSignalR = false;
        private bool isVisibilityDisconnected = true;

        private ObservableCollection<string> messagesReceived = new ObservableCollection<string>();


        public string Status
        {
            get => this.status;
            set => this.SetProperty(ref this.status, value);
        }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        public string Message
        {
            get => this.message;
            set
            {
                this.SetProperty(ref this.message, value);
            }
        }

        public bool IsVisibilityConnected
        {
            get => this.isVisibilityConnected;
            set => this.SetProperty(ref this.isVisibilityConnected, value);
        }


        public bool IsVisibilityDisconnected
        {
            get => this.isVisibilityDisconnected;
            set => this.SetProperty(ref this.isVisibilityDisconnected, value);
        }


        public bool IsConnectToSignalR
        {
            get => this.isConnectToSignalR;
            set => this.SetProperty(ref this.isConnectToSignalR, value);
        }

        public bool IsDisconnectToSignalR
        {
            get => this.isDisconnectToSignalR;
            set => this.SetProperty(ref this.isDisconnectToSignalR, value);
        }

        public ObservableCollection<string> MessagesReceived
        {
            get => this.messagesReceived;
            set => this.SetProperty(ref this.messagesReceived, value);
        }
    }
}
