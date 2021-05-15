namespace Jaroszek.PoC.SignalRChat.Application
{
    using System.Reflection;
    using Jaroszek.PoC.SignalRChat.Application.Behaviours;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            return services;
        }
    }
}