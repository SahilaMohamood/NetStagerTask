using static SurveyApp.Models.Question;

namespace SurveyApp.Models
{
    public class SurveyResponseViewModel
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public List<QuestionResponse> Responses { get; set; } = new List<QuestionResponse>();

    }

    public class QuestionResponse
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public string Answer { get; set; }
    }

}
