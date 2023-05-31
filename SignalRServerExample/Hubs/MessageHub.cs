using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        {
            #region Caller
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Others
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region AllExpect
            //Belirtilen id ler hariç mesaj gider
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            //Belirtilen id dekine mesaj gider
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            //Belirtilen id lere mesaj gider
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Group
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region GroupExpect
            // Belirtilen gruptaki belirtilen id ler dışındakilere mesaj gider.
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Groups
            // gruplara bildirimde bulunur
            //await Clients.Groups(groups).SendAsync("receiveMessage", message);
            #endregion

            #region OthersInGroup
            // bildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunur
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region User
            // auth olan kullanıcıya erişmek için
            #endregion

            #region Users
            // auth olan kullanıcılara atar
            #endregion

        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
