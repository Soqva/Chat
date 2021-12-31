using Chat.DesktopClient.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Chat.DesktopClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand SendMessageCommand { get; private set; }

        public ObservableCollection<string> ReceivedMessages { get; set; }

        private readonly MessageService _messageService;

        private string _messageStringToSend;
        public string MessageStringToSend
        {
            get => _messageStringToSend;
            set => SetProperty(ref _messageStringToSend, value);
        }

        public MainWindowViewModel()
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
            ReceivedMessages = new ObservableCollection<string>();
            _messageService = new MessageService();
            _messageService.ReceiveEvent += ReceiveMessage;
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(_messageStringToSend))
            {
                _messageService.SendMessage(_messageStringToSend);
                MessageStringToSend = "";
            }
        }

        private void ReceiveMessage()
        {
            string receivedMessageString = _messageService.ReceivedMessageObject.User.Name + ": " + _messageService.ReceivedMessageObject.Text;
            System.Windows.Application.Current.Dispatcher.Invoke(() => ReceivedMessages.Add(receivedMessageString));
        }
    }
}
