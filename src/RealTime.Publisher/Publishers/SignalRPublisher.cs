using Microsoft.AspNetCore.SignalR.Client;
using RealTime.Publisher.Model;

namespace RealTime.Publisher.Publishers
{
    internal class SignalRPublisher
    {
        public void Start()
        {

            Console.WriteLine("SignalR Publisher está sendo iniciado...");

            var url = "https://localhost:7000/chat-signalr";

            var connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            connection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                    Console.WriteLine(task.Exception.GetBaseException());
                else
                    Console.WriteLine("Conectado ao Hub");

            }).Wait();

            DoSendMessageAsync(connection);
        }

        private async void DoSendMessageAsync(HubConnection connection)
        {
            while (true)
            {
                await connection.InvokeAsync("SendMessage", new Message("All", "SignalR - Mensagem Ok!"));

                Thread.Sleep(2000);
            }
        }

    }
}
