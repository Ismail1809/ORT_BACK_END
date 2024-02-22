using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Models
{
    public class QuestionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public ICollection<QuestionAnswerModel>? QuestionAnswers { get; set; }
        public CorrectAnswerModel? CorrectAnswer { get; set; }
        //public QuestionAnswerModel[] QuestionAnswers { get; set; }
        //public CorrectAnswerModel CorrectAnswer { get; set; }
    }
    
}
