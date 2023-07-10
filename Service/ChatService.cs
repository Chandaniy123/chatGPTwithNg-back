using ChatGpt_back.Model;
using ChatGpt_back.Repository;
using Microsoft.AspNetCore.Mvc;

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

        public bool Editchat(EditChatModel editChatModel)
        {
            Chat chat=_chatRepo.GetAllChatById(editChatModel.Id);
            if(chat == null)
            {
                return false;
            }
            else
            {
                chat.Answer = editChatModel.Text;
                int IsChatEdited = _chatRepo.EditChat(chat);
                if(IsChatEdited == 0)
                { 
                    return false;
                }
                return true;
               
               
                
            }
        }

        public List<Chat> GetAllChatsByUserId(string id)
        {
            return _chatRepo.GetAllChatsByUserId(id);
        }

        public List<seguestionQusetion> GetAllQuestions()
        {
            return _chatRepo.GetAllQuestions();
        }

        
    }
}
