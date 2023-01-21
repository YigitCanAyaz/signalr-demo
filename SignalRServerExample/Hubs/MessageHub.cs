using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
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

            //await Clients.All.SendAsync("receiveMessage", message);

            #region Hub Clients Metodları

            // AllExcept
            #region AllExcept

            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);

            #endregion

            // Client
            #region Client

            await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);

            #endregion
            // Clients
            // Group
            // GroupExcept
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
