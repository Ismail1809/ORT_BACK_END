using OrtBackEnd.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.ModelsDTO
{
    public class QuestionModelDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public ICollection<QuestionAnswerModel>? QuestionAnswers { get; set; }
    }
}
