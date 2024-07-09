using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrtBackEnd.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int TestAttemptId { get; set; }
        public int SelectedOptionID { get; set; }
    }
}
