using OrtBackEnd.Controllers.RequestsAndResponses.QuestionExchanges;
using OrtBackEnd.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrtBackEnd.Controllers.RequestsAndResponses.QuestionOptionExchanges
{
    public class QuestionOptionCreateRequest
    {
        public string Text { get; set; }
        public bool? IsCorrect { get; set; }
        [JsonIgnore]
        public QuestionCreateRequest Question { get; set; }
    }
}
