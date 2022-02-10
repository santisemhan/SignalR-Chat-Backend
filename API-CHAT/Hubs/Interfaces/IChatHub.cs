namespace API_CHAT.Hubs.Interfaces
{
    using API_CHAT.ViewModels.Chat;
    using System.Threading.Tasks;
    public interface IChatHub
    {
        Task ReceiveMessage(ChatDTO message);
    }
}
