using ChatGpt_back.Model;

namespace ChatGpt_back.Service
{
    public interface IChatService
    {
        bool AddChat(Chat chat);
        bool AddQuestion(seguestionQusetion question);
        bool DeleteChat(int id);
        bool Editchat(EditChatModel editChatModel);
        List<Chat> GetAllChatsByUserId(string id);
        List<seguestionQusetion> GetAllQuestions();
    }
}
