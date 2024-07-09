namespace OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges
{
    public class TestAttemptResponse
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Score { get; set; }
    }
}
