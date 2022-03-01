namespace API_CHAT.Hubs
{
    using API_CHAT.Hubs.Interfaces;
    using API_CHAT.ViewModels.Chat;
    using Microsoft.AspNetCore.SignalR;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ChatHub : Hub<IChatHub>
    {
        private readonly IDictionary<string, UserConnection> _connections;
        private readonly string room;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _connections = connections;

            // Always join in the same room
            room = "1";
        }

        /// <summary>
        ///  Recibo el mensaje a enviar y se lo envio al grupo correspondiente.
        /// </summary>
        /// <param name="message">
        ///    Mensaje para enviar a los usuarios conectados en el chat. 
        /// </param>
        public async Task SendMessage(ChatDTO message)
        {
            message.AuthorId = Context.ConnectionId;

            await Clients.Group(room).ReceiveMessage(message);
        }

        /// <summary>
        ///   Se agrega a usuarios conectados al usuario recibido por parametro, se envia
        ///   su connectionId y se le avisa a los demas usuarios que dicho usuario se ha conectado.
        /// </summary>
        /// <param name="userConnection">
        ///    Usuario conectado
        /// </param>
        public async Task Connect(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            _connections[Context.ConnectionId] = userConnection;

            Clients.Client(Context.ConnectionId).ReciveConnectionId(Context.ConnectionId);

            await SendConnectedUsers();
        }

        /// <summary>
        /// Se intenta desconectar al usuario logueado y se le avisa a los demas
        /// usuarios de esta desconexion.
        /// </summary>
        public async Task Disconnect()
        {
            if (_connections.TryGetValue(Context.ConnectionId, out var userConnection))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
                _connections.Remove(Context.ConnectionId);

                await SendConnectedUsers();
            }
        }

        /// <summary>
        /// Se envia los usuarios conectados en el momento de llamar al metodo.
        /// </summary>
        public async Task SendConnectedUsers()
        {
            var users = _connections.Values;

            await Clients.Group(room).ReciveConnectedUsers(users);
        }
    }
}
