using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
