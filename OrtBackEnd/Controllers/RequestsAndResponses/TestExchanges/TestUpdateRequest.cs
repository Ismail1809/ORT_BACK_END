using OrtBackEnd.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.Controllers.RequestsAndResponses.TestExchanges
{
    public class TestUpdateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
