using ChatGpt_back.Model;
using ChatGpt_back.Repository;

namespace ChatGpt_back.Service
{
    public class ChatService : IChatService
    {
        readonly IChatRepo _chatRepo;
        public ChatService(IChatRepo chatRepo)
        {
            _chatRepo = chatRepo;
        }

        public bool AddChat(Chat chat)
        {
            try
            {
                int isChatAdded = _chatRepo.AddChat(chat);
                if (isChatAdded > 0)
                {
                    return true;
                }
                else return false;
            }
            catch {
                throw new Exception("Chat Not Added");
            }
        }

        public bool AddQuestion(seguestionQusetion question)
        {
            int isQuestionAdded = _chatRepo.AddQuestion(question);
            if(isQuestionAdded == 0)
            {
                return false;
            }
            return true;
        }

        public bool DeleteChat(int id)
        {
            int isChatDeleted = _chatRepo.DeleteChat(id);
            if (isChatDeleted == 0)
            {
                return false;
            }
            return true;
        }

        public List<Chat> GetAllChatsByUserId(int id)
        {
            return _chatRepo.GetAllChatsByUserId(id);
        }

        public List<seguestionQusetion> GetAllQuestions()
        {
            return _chatRepo.GetAllQuestions();
        }

        public User LoginUser(Login login)
        {
            User user1 = _chatRepo.GetUserById(login.Email);
            if (user1 == null)
            {
                throw new Exception("Email Not Present");
            }
            else
            {
                User isUserLogin = _chatRepo.LoginUser(login);
                if (isUserLogin == null)
                {
                    return null;
                }
                else
                    return isUserLogin;
            }
        }

        public bool PostUser(User user)
        {
            User user1 = _chatRepo.GetUserById(user.Email);
            if(user1 != null)
            {
                throw new Exception("Email Already Present");
            }
            else
            {
                int isUserAdded = _chatRepo.PostUser(user);
                if(isUserAdded == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
