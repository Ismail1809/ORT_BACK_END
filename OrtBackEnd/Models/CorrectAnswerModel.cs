using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrtBackEnd.Models
{
    public class CorrectAnswerModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int CorrectAnswerId { get; set; }

        [ForeignKey(nameof(QuestionModel))]
        public int QuestionId { get; set; }

        public string? AnswerText { get; set; }

        public QuestionModel? QuestionModel { get; set; }
    }
}
