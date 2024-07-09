using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges
{
    public class UserResponse
    {
        [Key]
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }
}
