using ChatGpt_back.Model;

namespace ChatGpt_back.Repository
{
    public interface IChatRepo
    {
        int AddChat(Chat chat);
        int AddQuestion(seguestionQusetion question);
        int DeleteChat(int id);
        int EditChat(Chat chat);
        Chat GetAllChatById(int id);
        List<Chat> GetAllChatsByUserId(string id);
        List<seguestionQusetion> GetAllQuestions();

    }
}
