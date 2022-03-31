using RealTime.Server.Hubs;

namespace RealTime.Server.Configuration;

public static class SignalRConfig
{
    public static IServiceCollection AddSignalRConfiguration(this IServiceCollection services)
    {
        services.AddSignalR();

        return services;
    }

    public static WebApplication UseSignalRConfiguration(this WebApplication app)
    {
        app.UseWebSockets();

        app.UseEndpoints(endpoint =>
        {
            endpoint.MapHub<ChatHub>("/chat-signalr");
        });

        return app;
    }
}



