using Microsoft.AspNetCore.SignalR.Client;
using RealTime.Consumer.Model;

namespace RealTime.Consumer.Consumers;
internal class SignalRConsumer
{
    public async void Start()
    {
        Console.WriteLine("SignalR Consumer está sendo iniciado...");

        var url = "https://localhost:7000/chat-signalr";

        var connection = new HubConnectionBuilder()
            .WithUrl(url)
            .WithAutomaticReconnect()
            .Build();

        connection.On<Message>("ReceiveMessage", (message) => ConsumeMessage(message));

        await connection.StartAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Console.WriteLine(task.Exception.GetBaseException());
            else
                Console.WriteLine("Conectado ao Hub");

        });
    }

    private void ConsumeMessage(Message message)
    {
        Console.WriteLine($"{message.UserName}: {message.Text}");
    }

}
