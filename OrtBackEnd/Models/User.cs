using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StudentId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public int Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
