using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrtBackEnd.Models
{
    public class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TestId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int CreatorId { get; set; }
        public int TimeLimit { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public ICollection<Question>? Questions { get; set; }
    }
}
