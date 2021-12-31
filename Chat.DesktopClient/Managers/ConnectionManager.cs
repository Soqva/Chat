using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using Core;

namespace Chat.DesktopClient.Managers
{
    class ConnectionManager
    {
        private readonly string _api;

        public ClientWebSocket Client { get; private set; }

        public User User { get; private set; }

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
        }
    }
}
