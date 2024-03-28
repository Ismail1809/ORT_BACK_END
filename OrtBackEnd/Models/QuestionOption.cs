using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrtBackEnd.Models
{
    public class QuestionOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public string? Text { get; set; }
        public bool? IsCorrect { get; set; }
        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
