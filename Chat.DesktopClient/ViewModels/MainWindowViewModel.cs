using Chat.DesktopClient.Services;
using Core;
using Prism.Commands;
using Prism.Mvvm;

namespace Chat.DesktopClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand SendMessageCommand { get; private set; }

        private readonly MessageService _messageService;

        private string _messageStringToSend;
        public string MessageStringToSend
        {
            get => _messageStringToSend;
            set => SetProperty(ref _messageStringToSend, value);
        }

        private string _receivedMessages;
        public string ReceivedMessages
        {
            get => _receivedMessages;
            set => SetProperty(ref _receivedMessages, _receivedMessages + "\n" + value);
        }

        public MainWindowViewModel()
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
            _messageService = new MessageService(this);
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(_messageStringToSend))
            {
                _messageService.SendMessage(_messageStringToSend);
                MessageStringToSend = "";
            }
        }

        public void ReceiveMessage(Message messageObject)
        {
            string receivedMessageString = messageObject.User.Name + ": " + messageObject.Text;
            ReceivedMessages = receivedMessageString;
        }
    }
}
