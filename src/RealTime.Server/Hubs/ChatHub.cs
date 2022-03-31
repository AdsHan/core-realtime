using Microsoft.AspNetCore.SignalR;
using RealTime.Server.Model;

namespace RealTime.Server.Hubs;

public class ChatHub : Hub
{
    public Task SendMessage(Message message)
    {
        Clients.All.SendAsync("ReceiveMessage", message);

        return Task.CompletedTask;
    }
}
