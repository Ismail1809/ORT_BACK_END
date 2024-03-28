using AutoMapper;
using OrtBackEnd.Controllers.RequestsAndResponses.QuestionExchanges;
using OrtBackEnd.Controllers.RequestsAndResponses.QuestionOptionExchanges;
using OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges;
using OrtBackEnd.Controllers.RequestsAndResponses.TestExchanges;
using OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges;
using OrtBackEnd.Models;

namespace OrtBackEnd.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserUpdateRequest, User>();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<TestUpdateRequest, Test>();
            CreateMap<Test, TestResponse>();
            CreateMap<TestCreateRequest, Test>();
            CreateMap<QuestionUpdateRequest, Question>();
            CreateMap<QuestionCreateRequest, Question>();
            CreateMap<QuestionOptionUpdateRequest, QuestionOption>();
            CreateMap<QuestionOptionCreateRequest, QuestionOption>();
            CreateMap<TestAttemptsCreateRequest, TestAttempt>();
            CreateMap<TestAttemptsUpdateRequest, TestAttempt>();
            CreateMap<TestAttempt, TestAttemptResultResponse>();
            CreateMap<TestAttempt, TestAttemptResponse>();
        }
    }
}
