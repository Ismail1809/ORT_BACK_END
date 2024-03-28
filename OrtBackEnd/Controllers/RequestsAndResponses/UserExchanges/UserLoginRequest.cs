namespace OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges
{
    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
