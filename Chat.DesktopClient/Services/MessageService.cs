using System;
using System.Text;
using System.Net.WebSockets;
using System.Threading;
using Core;
using Chat.DesktopClient.Managers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Chat.DesktopClient.Repositories;

namespace Chat.DesktopClient.Services
{
    public class MessageService
    {
        public event Action ReceiveEvent;

        public Message ReceivedMessageObject { get; set; }

        private const string API = "message";

        private readonly ConnectionManager _connectionManager;

        private readonly MessageRepository _messageRepository;

 
        public MessageService()
        {
            _connectionManager = new ConnectionManager(API);
            _messageRepository = new MessageRepository();
            _ = _connectionManager.StartConnection();
            _ = Task.Run(() => ReceiveMessageAsync());
        }

        public void SendMessage(string messageStringToSend)
        {
            Message messageObjectToSend = new Message
            {
                User = _connectionManager.User,
                Text = messageStringToSend
            };

            Task.Run(() => _messageRepository.Save(messageObjectToSend));

            string jsonMessageToSend = JsonConvert.SerializeObject(messageObjectToSend);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonMessageToSend);

            _ = _connectionManager.Client.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task ReceiveMessageAsync()
        {
            byte[] buffer = new byte[1024 * 4];

            while (true)
            {
                WebSocketReceiveResult receiveResult = await _connectionManager.Client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                string jsonReceivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                
                if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await _connectionManager.Client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    break;
                }

                ReceivedMessageObject = JsonConvert.DeserializeObject<Message>(jsonReceivedMessage);
                ReceiveEvent?.Invoke();
            }
        }
    }
}
