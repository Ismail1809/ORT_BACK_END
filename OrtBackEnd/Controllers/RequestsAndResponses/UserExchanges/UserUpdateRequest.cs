using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges
{
    public class UserUpdateRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
