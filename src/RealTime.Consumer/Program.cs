using RealTime.Consumer.Consumers;

class Program
{
    static void Main(string[] args)
    {
        var connectionSignalR = new SignalRConsumer();
        connectionSignalR.Start();

        var connectionWebSocket = new WebSocketConsumer();
        connectionWebSocket.Start();

        Console.Read();
    }
}