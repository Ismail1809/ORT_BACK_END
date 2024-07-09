namespace OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
