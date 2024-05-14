namespace SurveyApp.Models
{
    public class SurveyCreateViewModel
    {
        public Survey Survey { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

    }
}
