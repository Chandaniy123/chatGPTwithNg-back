using ChatGpt_back.Model;

namespace ChatGpt_back.Repository
{
    public interface IChatRepo
    {
        int AddChat(Chat chat);
        int AddQuestion(seguestionQusetion question);
        int DeleteChat(int id);
        List<Chat> GetAllChatsByUserId(int id);
        List<seguestionQusetion> GetAllQuestions();
        User GetUserById(string email);
        User LoginUser(Login login);
        int PostUser(User user);
    }
}
