namespace Jaroszek.PoC.SignalRChat.Client
{
    using Jaroszek.PoC.SignalRChat.Client.Interfaces;
    using Jaroszek.PoC.SignalRChat.Client.Services;
    using Jaroszek.PoC.SignalRChat.Client.Views;

    using Microsoft.Extensions.Logging;

    using Prism.Ioc;
    using Prism.Unity;

    using Serilog;
    using Serilog.Extensions.Logging;
    using Serilog.Sinks.Graylog;

    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Graylog(new GraylogSinkOptions
                {
                    HostnameOrAddress = "localhost",
                    Port = 12201,
                })
                .CreateLogger();

            base.OnStartup(e);

        }

        protected override void OnExit(ExitEventArgs e)
        {
            Log.CloseAndFlush();
            base.OnExit(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoggerFactory, SerilogLoggerFactory>();
            containerRegistry.RegisterInstance<IBackgroundService>(this.Container.Resolve<ShellBackgroundService>());
        }

        protected override Window CreateShell() => this.Container.Resolve<ShellView>();
    }
}

