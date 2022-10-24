using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class MessageHub:Hub
    {
       //public async Task SendMessageAsync(string message ,IEnumerable<string>connectionIds)
       public async Task SendMessageAsync(string message, string groupname)

        {
            //await Clients.Others.SendAsync("receiveMessage",message); //gönderenin kendisi hariç tüm clientlara mesaj gider.
            //await Clients.All.SendAsync("receiveMessage", message); //herkese mesaj gönderir.
            //await Clients.Caller.SendAsync("receiveMessage", message); //sadece gönderdigi mesajı kendisi görür.

            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message); //belirtilen clientlar hariç diger clientlere mesaj gönderir.  IEnumerable<string>ekledik.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message); ///clientlardan sadece girilen id ye gönderir.

            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);  //belirtilen id lere mesaj gönderme
            //await Clients.Groups(groupname).SendAsync("receiveMessage", message);
            await Clients.OthersInGroup(groupname).SendAsync("receiveMessage", message);

        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("GetConnectionId", Context.ConnectionId);
        }

        public async Task addgroup(string connectionId,string groupname)
        {
            await Groups.AddToGroupAsync(connectionId, groupname);
        }
    }
}
