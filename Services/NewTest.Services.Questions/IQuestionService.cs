namespace NewTest.Services.Questions
{
    public interface IQuestionService
    {
        Task<QuestionModel> GetById(Guid id);
        Task<QuestionModel> CreateResult(CreateResultModel model);
    }
}
