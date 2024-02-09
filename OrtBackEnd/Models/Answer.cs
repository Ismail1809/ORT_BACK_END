using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Models
{
    public class Answer
    {
        [Key]
        public int QuestionId { get; set; }
        public string? UserAnswer { get; set; }
    }
}
