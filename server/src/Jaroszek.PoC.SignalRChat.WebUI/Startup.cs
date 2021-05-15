namespace Jaroszek.PoC.SignalRChat.WebUI
{
    using System.Reflection;
    using Hangfire;
    using Hangfire.MemoryStorage;
    using Jaroszek.PoC.SignalRChat.Application;
    using Jaroszek.PoC.SignalRChat.Infrastructure;
    using Jaroszek.PoC.SignalRChat.WebUI.Hubs;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddSerilog());
            services.AddHealthChecks();

            GlobalConfiguration.Configuration.UseSerilogLogProvider();

            services.AddHangfire(config => config.UseMemoryStorage());

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplication();
            services.AddInfrastructure();

            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jaroszek.PoC.SignalRChat.WebUI", Version = "v1" }));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    }));


            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jaroszek.PoC.SignalRChat.WebUI v1"));

            app.UseHttpsRedirection();

            app.UseHealthChecks("/health");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
