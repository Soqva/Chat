using Core;
using Microsoft.EntityFrameworkCore;

namespace Chat.DesktopClient.DataBaseContext
{
    class ChatContext : DbContext
    {
        public DbSet<MessageToRepo> MessagesFromUsers { get; set; }

        public ChatContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=chat;Username=postgres;Password=postgres");
        }
    }
}
