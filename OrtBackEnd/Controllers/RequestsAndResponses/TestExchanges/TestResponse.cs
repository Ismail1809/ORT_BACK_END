using OrtBackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Controllers.RequestsAndResponses.TestExchanges
{
    public class TestResponse
    {
        [Key]
        public int TestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int TimeLimit { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
