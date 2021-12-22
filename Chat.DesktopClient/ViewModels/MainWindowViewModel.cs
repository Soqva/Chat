namespace Chat.DesktopClient.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Services;

    public class MainWindowViewModel : BindableBase
    {
        private readonly MessageService _messageService;

        private string _message = "";

        public string Message
        {
            get => "";
            set => SetProperty(ref _message, value);
        }

        private string _output = "";

        public string Output
        {
            get => _output;
            set => SetProperty(ref _output, _output + RecieveMessage());
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MainWindowViewModel()
        {
            _messageService = new MessageService();
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _messageService.SendMessage(_message);
        }

        private string RecieveMessage()
        {
            return _messageService.RecieveMessage().Result;
        }
    }
}
