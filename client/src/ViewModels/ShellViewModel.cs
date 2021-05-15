﻿namespace Jaroszek.PoC.SignalRChat.Client.ViewModels
{
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