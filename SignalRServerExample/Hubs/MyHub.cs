using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        // bağlı olan kullanıcıları inmemory'de tutacağız
        static List<string> clients = new List<string>();

        //public async Task SendMessageAsync(string message)
        //{
        //    // receiveMessage => client'taki fonskyion
        //    await Clients.All.SendAsync("receiveMessage", message);
        //}

        // Bir bağlantı gerçekleşince
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);

            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);

            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }

        // Bir bağlantı kopunca
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);

            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeft", Context.ConnectionId);

            await Clients.All.Clients(clients);
            await Clients.All.UserLeft(Context.ConnectionId);
        }
    }
}