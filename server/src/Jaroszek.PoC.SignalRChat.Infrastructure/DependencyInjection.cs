namespace Jaroszek.PoC.SignalRChat.Infrastructure
{
    using System.Reflection;
    using Jaroszek.PoC.SignalRChat.Infrastructure.Services;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
