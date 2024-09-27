using AutoMapper;
using NewTest.Services.Questions;

namespace NewTest.Api.Contrellers.Models
{
    public class ResponseCreateResultModel
    {
        public Guid Id { get; set; }
    }
    public class ResponseCreateResultModelProfile : Profile
    {
        public ResponseCreateResultModelProfile()
        {
            CreateMap<QuestionModel, ResponseCreateResultModel>();
        }
    }
}
