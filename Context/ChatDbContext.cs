using ChatGpt_back.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatGpt_back.Context
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)  {  }
        public DbSet<seguestionQusetion> Question { get; set; }
        public DbSet<Chat> chats { get; set; }
        public DbSet<User> users { get; set; }
    }
}

