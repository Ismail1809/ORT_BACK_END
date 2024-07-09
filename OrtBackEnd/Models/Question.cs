using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrtBackEnd.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionId { get; set; }
        [ForeignKey(nameof(Test))]
        public int TestId { get; set; }
        public string? Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public Test? Test { get; set; }
        public ICollection<QuestionOption>? QuestionOptions { get; set; }

    }
}
