using RealTime.Server.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddSignalRConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSignalRConfiguration();
app.UseWebSocketsConfiguration();

app.Run();
