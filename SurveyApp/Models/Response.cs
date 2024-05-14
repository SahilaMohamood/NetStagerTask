namespace SurveyApp.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
