using ChatGpt_back.Context;
using ChatGpt_back.Model;
using System;

namespace ChatGpt_back.Repository
{
    public class ChatRepo : IChatRepo
    {
        readonly ChatDbContext chatDbContext;
        public ChatRepo(ChatDbContext chatDbContext)
        {
            this.chatDbContext = chatDbContext;
        }

        public int AddChat(Chat chat)
        {
            chatDbContext.chats.Add(chat);
            int chatAdded = chatDbContext.SaveChanges();
            return chatAdded;
        }

        public int AddQuestion(seguestionQusetion question)
        {
            chatDbContext.Question.Add(question);
            int row = chatDbContext.SaveChanges();
            if (row == 0)
                return 0;
            else
                return 1;
        }

        public int DeleteChat(int id)
        {
            Chat chatchat = chatDbContext.chats.Where(x => x.Id == id).FirstOrDefault();
            chatDbContext.chats.Remove(chatchat);
            int chatDeleted = chatDbContext.SaveChanges();
            return chatDeleted;
        }

        public List<Chat> GetAllChatsByUserId(int id)
        {
            return chatDbContext.chats.Where(c => c.UserId == id).ToList();
        }

        public List<seguestionQusetion> GetAllQuestions()
        {
            return chatDbContext.Question.ToList();
        }

        public User GetUserById(string email)
        {
            return chatDbContext.users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User LoginUser(Login login)
        {
            return chatDbContext.users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
        }

        public int PostUser(User user)
        {
            chatDbContext.users.Add(user);  
            return chatDbContext.SaveChanges();
        }
    }
}
