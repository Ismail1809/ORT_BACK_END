using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrtBackEnd.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? CorrectAnswer { get; set; }
    }
}
