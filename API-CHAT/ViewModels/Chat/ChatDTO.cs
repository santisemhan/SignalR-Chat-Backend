namespace API_CHAT.ViewModels.Chat
{
    using System;
    public class ChatDTO
    {
        /// <summary>
        /// ConnectionId con el webSocket del usuario 
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// Nombre del usuario 
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Imagen de perfil del usuario 
        /// </summary>
        public string AuthorImageURL { get; set; }

        /// <summary>
        /// Mensaje del usuario a enviar
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Imagen del usuario a enviar
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// Fecha y horario del mensaje enviado
        /// </summary>
        public DateTime DateTime { get; set; }

    }
}
