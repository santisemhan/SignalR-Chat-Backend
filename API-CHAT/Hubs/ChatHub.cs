namespace API_CHAT.Hubs
{
    using API_CHAT.Hubs.Interfaces;
    using API_CHAT.ViewModels.Chat;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class ChatHub : Hub<IChatHub>
    {
        public Task SendMessage(ChatDTO message)
        {
            return Clients.All.ReceiveMessage(message);
        }
    }
}
