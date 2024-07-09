using AutoMapper.Configuration.Annotations;
using OrtBackEnd.Controllers.RequestsAndResponses.QuestionOptionExchanges;
using OrtBackEnd.Models;
using System.Data;
using System.Text.Json.Serialization;

namespace OrtBackEnd.Controllers.RequestsAndResponses.QuestionExchanges
{
    public class QuestionCreateRequest
    {
        public int TestId { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<QuestionOptionCreateRequest> QuestionOptions { get; set; }
    }
}
