using OrtBackEnd.Controllers.RequestsAndResponses.QuestionOptionExchanges;
using OrtBackEnd.Controllers.RequestsAndResponses.TestExchanges;
using OrtBackEnd.Models;

namespace OrtBackEnd.Controllers.RequestsAndResponses.QuestionExchanges
{
    public class QuestionUpdateRequest
    {
        public string Text { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<QuestionOptionUpdateRequest> QuestionOptions { get; set; }
    }
}
