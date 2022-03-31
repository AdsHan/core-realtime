namespace RealTime.Server.Configuration;

public static class ApiConfig
{

    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        // Adiciona a política CORS
        services.AddCors(options =>
        {
            options.AddPolicy("Total",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });

        return services;
    }

    public static WebApplication UseApiConfiguration(this WebApplication app)
    {
        app.UseRouting();

        return app;
    }
}



