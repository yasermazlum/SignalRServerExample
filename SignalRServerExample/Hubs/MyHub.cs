using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs;

public class MyHub : Hub<IMessageClient>
{
    static List<string> clients = new List<string>();
    //public async Task SendMessageAsync(string message)
    //{
    //    await Clients.All.SendAsync("receiveMessage", message);
    //}

    public override async Task OnConnectedAsync()
    {
        string cId = Context.ConnectionId;
        clients.Add(cId);
        //await Clients.All.SendAsync("clients", clients);
        //await Clients.All.SendAsync("userConnected", cId);
        await Clients.All.Clients(clients);
        await Clients.All.UserConnected(cId);

    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string cId = Context.ConnectionId;
        clients.Remove(cId);
        //await Clients.All.SendAsync("userDisconnected", cId);
        await Clients.All.Clients(clients);
        await Clients.All.UserDisonnected(cId);
    }
}