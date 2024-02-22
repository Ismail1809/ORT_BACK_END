using AutoMapper;
using OrtBackEnd.Models;
using OrtBackEnd.ModelsDTO;

namespace OrtBackEnd.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<QuestionModel, QuestionModelDTO>();
        }
    }
}
