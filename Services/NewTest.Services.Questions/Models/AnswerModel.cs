using AutoMapper;
using NewTest.Context;
using NewTest.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace NewTest.Services.Questions
{
    public class AnswerModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
    public class AnswerModelProfile : Profile
    {
        public AnswerModelProfile()
        {
            CreateMap<Answer, AnswerModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Uid))
                ;
        }
    }
}
