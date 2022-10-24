
using Microsoft.AspNetCore.SignalR;
using SignalR.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class MyHub :Hub<IMessageClient>
    {
        static List<string> kisiler = new List<string>();

        public async Task SendMessageAsync(string message)
        {
            //await _hubContext.Clients.All.SendAsync("receiveMessage", message);
            //await Clients.All.SendAsync("receiveMessage", message);
            await Clients.All.receiveMessage(message);
        }
        public override async Task OnConnectedAsync()
        {
            kisiler.Add(Context.ConnectionId);
            await Clients.All.Clients(kisiler);
            await Clients.All.ClientJoined(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            kisiler.Remove(Context.ConnectionId);
            await Clients.All.Clients(kisiler);
            await Clients.All.ClientLeaved(Context.ConnectionId);
        }
    }
}
