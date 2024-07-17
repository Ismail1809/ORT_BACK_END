namespace OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges
{
    public class UserRegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
