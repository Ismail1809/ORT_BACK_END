using OrtBackEnd.Models;

namespace OrtBackEnd.Controllers.RequestsAndResponses.TestExchanges
{
    public class TestCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int TimeLimit { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
