using ChatGpt_back.Model;

namespace ChatGpt_back.Service
{
    public interface IChatService
    {
        bool AddChat(Chat chat);
        bool AddQuestion(seguestionQusetion question);
        bool DeleteChat(int id);
        List<Chat> GetAllChatsByUserId(int id);
        List<seguestionQusetion> GetAllQuestions();
        User LoginUser(Login login);
        bool PostUser(User user);
    }
}
