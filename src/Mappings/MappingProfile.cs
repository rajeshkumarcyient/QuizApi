using AutoMapper;
using QuizAppApi.Data;
using QuizAppApi.DTO;

namespace QuizAppApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quiz, QuizDto>();
        }
    }
}
