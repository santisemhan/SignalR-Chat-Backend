namespace API_CHAT.Hubs.Interfaces
{
    using API_CHAT.ViewModels.Chat;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IChatHub
    {
        /// <summary>
        /// Metodo para que el cliente ponga un lister en el webSocket y reciba los mensajes enviados.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task ReceiveMessage(ChatDTO message);

        /// <summary>
        /// Metodo para que el cliente ponga un lister en el webSocket y reciba los usuarios conectados.
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task ReciveConnectedUsers(ICollection<UserConnection> users);

        /// <summary>
        /// Metodo para que el cliente ponga un listener en el webSocket y reciba su conectionId.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        Task ReciveConnectionId(string connectionId);
    }
}
