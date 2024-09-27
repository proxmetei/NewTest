using AutoMapper;
using NewTest.Services.Questions;

namespace NewTest.Api.Contrellers.Models
{
    public class RequestCreateResultModel
    {
        public Guid AnswerId { get; set; }
        public Guid InterviewId { get; set; }
    }
    public class RequestCreateResultModelProfile : Profile
    {
        public RequestCreateResultModelProfile()
        {
            CreateMap<RequestCreateResultModel, CreateResultModel>();
        }
    }
}
