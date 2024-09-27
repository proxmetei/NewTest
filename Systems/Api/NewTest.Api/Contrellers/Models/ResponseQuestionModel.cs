using AutoMapper;
using NewTest.Context.Entities;
using NewTest.Services.Questions;

namespace NewTest.Api.Contrellers.Models
{
    public class ResponseQuestionModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
    public class ResponseQuestionModelProfile : Profile
    {
        public ResponseQuestionModelProfile()
        {
            CreateMap<QuestionModel, ResponseQuestionModel>();
        }
    }
}
