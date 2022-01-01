using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using Core;
using System.Text;
using Newtonsoft.Json;

namespace Chat.DesktopClient.Managers
{
    class ConnectionManager
    {
        public event EventHandler<Message> ReceivedMessageHandler;

        public ClientWebSocket Client { get; private set; }

        public User User { get; private set; }

        private readonly string _api;

        public ConnectionManager(string api)
        {
            _api = api;
        }

        public async Task StartConnection()
        {
            Client = new ClientWebSocket();

            User = new User
            {
                Id = Guid.NewGuid(),
                Name = $"User{new Random().Next(1, 1000)}"
            };

            await Client.ConnectAsync(new Uri($"ws://localhost:5000/{_api}"), CancellationToken.None);

            NLog.Logger logger = Logger.Logger.GetLogger();
            logger.Info($"{User.Name} connected to the server.");

            _ = ReceiveMessage();
        }

        private async Task ReceiveMessage()
        {
            byte[] buffer = new byte[1024 * 4];

            while (true)
            {
                WebSocketReceiveResult result = await Client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await Client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    break;
                }
                
                string jsonMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Message messageObject = JsonConvert.DeserializeObject<Message>(jsonMessage);
                
                ReceivedMessageHandler?.Invoke(this, messageObject);
            }
        }
    }
}
