using Chat.Server.SocketsManager;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Concurrent;
using Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Chat.Server.Handlers
{
    public class MessageHandler : SocketHandler
    {
        private readonly List<WebSocket> _connections = new();

        public MessageHandler(ConnectionManager connectionManager) : base(connectionManager)
        {

        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            _connections.Add(socket);

            Message message = new Message
            {
                User = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Someone"
                },
                Text = "connected"
            };

            await SendMessageToAll(message);
        }

        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Message messageObject = JsonConvert.DeserializeObject<Message>(message);

            await SendMessageToAll(messageObject);
        }
    }
}
