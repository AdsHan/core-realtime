using Newtonsoft.Json;
using RealTime.Server.Model;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace RealTime.Server.Configuration;

public static class WebSocketsConfig
{

    public static WebApplication UseWebSocketsConfiguration(this WebApplication app)
    {
        app.UseWebSockets();

        app.Map("/chat-websockets", async context =>
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Somente solicitações de WebSocket são permitidas");
                await context.Response.CompleteAsync();
                return;
            }

            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

            var message = new Message("All", "WebSocket - Mensagem Ok!");
            var data = JsonConvert.SerializeObject(message);
            var encoded = Encoding.UTF8.GetBytes(data);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);

            while (webSocket.State == WebSocketState.Open)
            {
                await webSocket.SendAsync(buffer, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
                await Task.Delay(2000);
            }

        });

        return app;
    }

}



