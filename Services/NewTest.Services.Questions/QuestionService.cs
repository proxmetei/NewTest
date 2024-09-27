using AutoMapper;
using NewTest.Shared.Validator;
using NewTest.Context;
using NewTest.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace NewTest.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<CreateResultModel> createResultModelValidator;
        public QuestionService(
            IDbContextFactory<MainDbContext> dbContextFactory,
            IMapper mapper,
            IModelValidator<CreateResultModel> createResultModelValidator
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.createResultModelValidator = createResultModelValidator;
        }
        public async Task<QuestionModel> GetById(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var question = await context.Questions
                .Include(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Uid == id);

            var result = mapper.Map<QuestionModel>(question);

            return result;
        }
        public async Task<QuestionModel?> CreateResult(CreateResultModel model)
        {
            await createResultModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var result = mapper.Map<Result>(model);

            var res = await context.Results.AddAsync(result);

            await context.SaveChangesAsync();

            var answer = context.Answers.FirstOrDefault(x => x.Uid == model.AnswerId);

            var interview = context.Interviews.FirstOrDefault(x => x.Uid == model.InterviewId);

            var nextNumber = answer.Question.SurveyQuestionNumbers.
                        FirstOrDefault(x => x.SurveyId == interview.SurveyId).Number + 1;
            var nextQuestionWithNumber = interview.Survey.SurveyQuestionNumbers
                    .FirstOrDefault(x => x.Number == nextNumber);
            if (nextQuestionWithNumber != null)
            {
                var nextQuestion = nextQuestionWithNumber.Question;
                return mapper.Map<QuestionModel>(nextQuestion);
            }
            else
                return null;
        }
    }
}
