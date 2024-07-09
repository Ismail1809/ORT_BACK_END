namespace OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges
{
    public class TestAttemptsCreateRequest
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartTime { get; set; }
    }
}
