using OrtBackEnd.Controllers.RequestsAndResponses.QuestionExchanges;
using System.Text.Json.Serialization;

namespace OrtBackEnd.Controllers.RequestsAndResponses.QuestionOptionExchanges
{
    public class QuestionOptionUpdateRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool? IsCorrect { get; set; }
        [JsonIgnore]
        public QuestionUpdateRequest Question { get; set; }
    }
}
