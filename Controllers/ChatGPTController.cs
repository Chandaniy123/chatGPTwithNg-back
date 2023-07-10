using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using ChatGpt_back.Service;
using ChatGpt_back.Model;

namespace ChatGpt_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        readonly IChatService _chatService;
        public ChatGPTController(IChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAnswer(string input)
        {
            string apiKey = "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";
            string response = "";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "text-davinci-003";
            completion.MaxTokens = 4000;
            var output = await openai.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Not found");
            }
        }

        [HttpPost]
        [Route("GetImage")]
        public async Task<IActionResult> GetImage(string input)
        {
            string apiKey = "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";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            var output =  openai.ImageGenerations.CreateImageAsync(input);
            
            if (output != null)
            {
                
                return Ok(output.Result.Data);
            }
            else
            {
                return BadRequest("Not found");
            }
        }

        [HttpPost]
        [Route("AddQuestion")]
        public IActionResult AddQuestion(seguestionQusetion question)
        {
            bool isQuestionAdded = _chatService.AddQuestion(question);
            return Ok("Question Added");
        }

        [HttpGet]
        [Route("GetAllQuestions")]
        public List<seguestionQusetion> GetAllQuestions()
        {
            List<seguestionQusetion> seguestionQusetions = _chatService.GetAllQuestions();
            return seguestionQusetions;
        }

        [HttpPost]
        [Route("AddChat")]
        public ActionResult AddChat(Chat chat)
        {
            if (chat == null)
            {
                return BadRequest("Chat must not be Null");
            }
            else
            {
                bool ischatAdded  = _chatService.AddChat(chat);
                if (ischatAdded)
                {
                    return Ok("Chat Added");
                }
                else
                    return BadRequest("Some Thing Wrong");
            }
            
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteChat(int id)
        {
            if (id == null)
            {
                return BadRequest("Chat must not be Null");
            }
            else
            {
                bool ischatDeleted = _chatService.DeleteChat(id);
                if (ischatDeleted)
                {
                    return Ok("Chat Deleted");
                }
                else
                    return BadRequest("Some Thing Wrong");
            }

        }


        [HttpGet]
        [Route("GetChatListByUserId/{id}")]
        public List<Chat> GetAllChatsByUserId(string id)
        {
            return _chatService.GetAllChatsByUserId(id);
        }


       
        [HttpPut]
        [Route("EditChat")]
        public ActionResult Editchat(EditChatModel editChatModel)
        {

            bool isChatUpdated=_chatService.Editchat(editChatModel);

           
            if(isChatUpdated)
            {
                return Ok(isChatUpdated);
            }
            return BadRequest("SomeThing Wrong");
        }
    }

}
