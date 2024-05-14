namespace SurveyApp.Models
{
    public class Question
    {

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
        public enum QuestionType
        {
            SingleChoice,
            MultipleChoice,
            OpenEnded
        }
    
}
