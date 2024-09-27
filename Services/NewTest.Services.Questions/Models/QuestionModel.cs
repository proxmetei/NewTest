using AutoMapper;
using NewTest.Context;
using NewTest.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace NewTest.Services.Questions
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
    public class QuestionModelProfile : Profile
    {
        public QuestionModelProfile()
        {
            CreateMap<Question, QuestionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Uid))
                ;
        }
    }
}
