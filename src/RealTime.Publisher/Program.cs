using RealTime.Publisher.Publishers;

class Program
{
    static async Task Main(string[] args)
    {
        var connectionSignalR = new SignalRPublisher();
        connectionSignalR.Start();

        Console.Read();
    }

}