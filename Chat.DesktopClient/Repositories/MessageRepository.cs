using Chat.DesktopClient.DataBaseContext;
using Core;

namespace Chat.DesktopClient.Repositories
{
    class MessageRepository
    {
        public void Save(Message messageObjectFromUser)
        {
            MessageToRepo messageToRepo = new MessageToRepo
            {
                Id = messageObjectFromUser.User.Id,
                Name = messageObjectFromUser.User.Name,
                Text = messageObjectFromUser.Text,
                SendTime = System.DateTime.Now
            };
            
            using (ChatContext dataBase = new ChatContext())
            {
                dataBase.MessagesFromUsers.Add(messageToRepo);
                dataBase.SaveChanges();
            }
        }
    }
}
