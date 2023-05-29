using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs;

public class MyHub : Hub
{
    static List<string> clients = new List<string>();
    public async Task SendMessageAsync(string message)
    {
        await Clients.All.SendAsync("receiveMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        string cId = Context.ConnectionId;
        clients.Add(cId);
        await Clients.All.SendAsync("clients", clients);
        await Clients.All.SendAsync("userConnected", cId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string cId = Context.ConnectionId;
        clients.Remove(cId);
        await Clients.All.SendAsync("userDisconnected", cId);
        //return base.OnDisconnectedAsync(exception);
    }
}