using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Models
{
    public class Tests
    {
        [Key]
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? CorrectAnswer { get; set; }
    }
}
