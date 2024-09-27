namespace NewTest.Services.Questions;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddQuestionService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IQuestionService, QuestionService>();
    }
}