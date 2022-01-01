using Chat.DesktopClient.Services;
using Core;
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

        private string _output = "";

        public string Output
        {
            get => _output;
            set => SetProperty(ref _output, value);
        }

        public MainWindowViewModel()
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
            ReceivedMessages = new ObservableCollection<string>();
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

        public void ReceiveMessage(Message message)
        {
            string receivedMessageString = message.User.Name + ": " + message.Text;
            if (Output.Length == 0) Output = receivedMessageString;
            else Output = $"{Output}\n{receivedMessageString}";
            //System.Windows.Application.Current.Dispatcher.Invoke(() => ReceivedMessages.Add(receivedMessageString));
        }
    }
}
