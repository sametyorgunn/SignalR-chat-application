using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> kisiler);
        Task ClientJoined(string connectionId);
        Task ClientLeaved(string connectionId);
        Task receiveMessage(string message);

    }
}
