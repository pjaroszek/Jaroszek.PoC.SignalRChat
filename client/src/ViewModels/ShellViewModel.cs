namespace Jaroszek.PoC.SignalRChat.Client.ViewModels
{
    using Jaroszek.PoC.SignalRChat.Client.Events;

    using Microsoft.Extensions.Logging;

    using Prism.Events;
    using Prism.Mvvm;

    using System;

    public sealed partial class ShellViewModel : BindableBase, IDisposable
    {
        private volatile bool disposed;

        private readonly IEventAggregator eventAgregator;
        private readonly ILogger<ShellViewModel> logger;

        public ShellViewModel()
        {

        }

        public ShellViewModel(IEventAggregator eventAgregator, ILoggerFactory loggeFactory) : this()
        {
            this.eventAgregator = eventAgregator;
            this.logger = loggeFactory.CreateLogger<ShellViewModel>();

            this.eventAgregator.GetEvent<ReceivedMessageSignalRResponse>().Subscribe(item =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate { this.MessagesReceived.Add(item.UserName + " says " + item.Message); });
            });


            this.eventAgregator.GetEvent<ChangeStatusRequestEvent>().Subscribe(s =>
            {
                this.Status = s;
            });

            this.logger.LogInformation($"Created {typeof(ShellViewModel)} object.");

        }

        ~ShellViewModel()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {

                this.logger.LogInformation("Dispose ShellViewModel Instance");
            }

            this.disposed = true;
        }
    }
}