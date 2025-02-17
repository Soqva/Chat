﻿using System;
using System.Text;
using System.Net.WebSockets;
using System.Threading;
using Core;
using Chat.DesktopClient.Managers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Chat.DesktopClient.Repositories;
using Chat.DesktopClient.ViewModels;

namespace Chat.DesktopClient.Services
{
    public class MessageService
    {
        public Message ReceivedMessageObject { get; set; }

        private const string API = "message";

        private readonly ConnectionManager _connectionManager;

        private readonly MessageRepository _messageRepository;

        private readonly MainWindowViewModel _mainWindowViewModel;


        public MessageService(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _messageRepository = new MessageRepository();
            _connectionManager = new ConnectionManager(API);
            _connectionManager.ReceivedMessageHandler += ReceiveMessage;
            _ = _connectionManager.StartConnection(); 
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

            NLog.Logger logger = Logger.Logger.GetLogger();
            logger.Info($"{messageObjectToSend.User.Name} sent \"{messageObjectToSend.Text}\" to the server.");
        }

        private void ReceiveMessage(object sender, Message messageObject)
        {
            _mainWindowViewModel.ReceiveMessage(messageObject);
        }
    }
}
