using AutoMapper;
using NewTest.Context;
using NewTest.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace NewTest.Services.Questions
{
    public class CreateResultModel
    {
        public Guid AnswerId { get; set; }
        public Guid InterviewId { get; set; }
    }
    public class CreateResultModelProfile : Profile
    {
        public CreateResultModelProfile()
        {
            CreateMap<CreateResultModel, Result>()
                .ForMember(dest => dest.AnswerId, opt => opt.Ignore())
                .ForMember(dest => dest.InterviewId, opt => opt.Ignore())
                .AfterMap<CreateResultModelActions>();
        }

        public class CreateResultModelActions : IMappingAction<CreateResultModel, Result>
        {
            private readonly IDbContextFactory<MainDbContext> contextFactory;

            public CreateResultModelActions(IDbContextFactory<MainDbContext> contextFactory)
            {
                this.contextFactory = contextFactory;
            }

            public void Process(CreateResultModel source, Result destination, ResolutionContext context)
            {
                using var db = contextFactory.CreateDbContext();

                var answer = db.Answers.FirstOrDefault(x => x.Uid == source.AnswerId);

                var interview = db.Interviews.FirstOrDefault(x => x.Uid == source.InterviewId);

                destination.AnswerId = answer.Id;

                destination.InterviewId = interview.Id;
            }
        }
    }

    public class CreateResultModelValidator : AbstractValidator<CreateResultModel>
    {
        public CreateResultModelValidator(IDbContextFactory<MainDbContext> contextFactory)
        {
            RuleFor(x => x.AnswerId)
                .NotEmpty().WithMessage("Answer is required")
                .Must((id) =>
                {
                    using var context = contextFactory.CreateDbContext();
                    var found = context.Answers.Any(a => a.Uid == id);
                    return found;
                }).WithMessage("Answer not found");

            RuleFor(x => x.InterviewId)
                .NotEmpty().WithMessage("Intreview is required")
                .Must((id) =>
                {
                    using var context = contextFactory.CreateDbContext();
                    var found = context.Interviews.Any(a => a.Uid == id);
                    return found;
                }).WithMessage("Interview not found");
            RuleFor(x => new { x.AnswerId, x.InterviewId })
                .Must((x) =>
                {
                    using var context = contextFactory.CreateDbContext();
                    var interview = context.Interviews.FirstOrDefault(a => a.Uid == x.InterviewId);
                    var answer = context.Answers.FirstOrDefault(a => a.Uid == x.AnswerId);
                    if (interview == null)
                        return false;
                    if (answer == null)
                        return false;
                    var surveyId = interview.SurveyId;
                    var numberOfQuestionForAnswer = answer.Question.SurveyQuestionNumbers.FirstOrDefault(a => a.SurveyId == surveyId).Number;
                    var results = interview.Results.ToList();
                    int numberOfQuestionForInterview = 1;
                    if (results.Count() != 0)
                    {
                        var numberForResults = results.Select(a => a.Answer.Question.SurveyQuestionNumbers.FirstOrDefault(a => a.SurveyId == surveyId).Number);
                        numberOfQuestionForInterview = numberForResults.Max() + 1;
                    }
                    return numberOfQuestionForAnswer == numberOfQuestionForInterview;
                }).WithMessage("This answer can not be in that interview");
        }
    }
}
