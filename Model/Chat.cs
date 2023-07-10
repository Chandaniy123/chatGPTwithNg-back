namespace ChatGpt_back.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
