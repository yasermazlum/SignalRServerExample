using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            #region Caller
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Others
            await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

           
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
