using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Data;
using SignalRServerExample.Models;

namespace SignalRServerExample.Hubs
{
    public class ChatHub:Hub
    {
        public async Task GetNickName(string nickName)
        {
            ClientModel model = new ClientModel
            {
                ConnectionId = Context.ConnectionId,
                UserNickName = nickName
            };

            ClientSource.Clients.Add(model);
            await Clients.Others.SendAsync("clientJoined", nickName);
            await Clients.All.SendAsync("clients", ClientSource.Clients);
        }
    }
}
