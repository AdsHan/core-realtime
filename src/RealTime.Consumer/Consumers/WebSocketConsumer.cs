using Newtonsoft.Json;
using RealTime.Consumer.Model;
using System.Net.WebSockets;
using System.Text;

namespace RealTime.Consumer.Consumers;
internal class WebSocketConsumer
{
    public async void Start()
    {
        Console.WriteLine("WebSocket Consumer está sendo iniciado...");

        using var connection = new ClientWebSocket();

        var url = "wss://localhost:7000/chat-websockets";

        await connection.ConnectAsync(new Uri(url), CancellationToken.None);

        var buffer = new byte[1024];

        while (connection.State == WebSocketState.Open)
        {
            var result = await connection.ReceiveAsync(buffer, CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await connection.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
            }
            else
            {
                var messageString = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var message = JsonConvert.DeserializeObject<Message>(messageString);

                Console.WriteLine($"{message.UserName}: {message.Text}");
            }
        }
    }
}
