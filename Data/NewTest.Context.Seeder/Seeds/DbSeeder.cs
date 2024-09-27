namespace NewTest.Context.Seeder;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewTest.Context.Entities;
using System;

public static class DbSeeder
{
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    }

    private static MainDbContext DbContext(IServiceProvider serviceProvider)
    {
        return ServiceScope(serviceProvider)
            .ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();
    }

    public static void Execute(IServiceProvider serviceProvider)
    {
        Task.Run(async () =>
            {
                await AddDemoSurveys(serviceProvider);
                await AddDemoInterviews(serviceProvider);
            })
            .GetAwaiter()
            .GetResult();
    }

    private static async Task AddDemoSurveys(IServiceProvider serviceProvider)
    {
        using var scope = ServiceScope(serviceProvider);
        if (scope == null)
            return;

        var settings = scope.ServiceProvider.GetService<DbSettings>();
        if (!(settings.Init?.AddDemoData ?? false))
            return;

        await using var context = DbContext(serviceProvider);

        if (await context.Surveys.AnyAsync())
            return;

        var surveys = new DemoHelper().GetSurveys;

        await context.Surveys.AddRangeAsync(surveys);

        await context.SaveChangesAsync();
    }
    private static async Task AddDemoInterviews(IServiceProvider serviceProvider)
    {
        using var scope = ServiceScope(serviceProvider);
        if (scope == null)
            return;

        var settings = scope.ServiceProvider.GetService<DbSettings>();
        if (!(settings.Init?.AddDemoData ?? false))
            return;

        await using var context = DbContext(serviceProvider);

        if (await context.Interviews.AnyAsync())
            return;

        var interviews = new DemoHelper().GetInterviews;

        Random rnd = new Random();

        var surveys = await context.Surveys.ToListAsync();

        bool oneHasNoAnswers = false;

        foreach (var interview in interviews)
        {
            var survay = surveys[rnd.Next(0, surveys.Count)];
            var answer1 = survay.SurveyQuestionNumbers.Where(x => x.Number == 1).FirstOrDefault().Question.Answers.ElementAt(0).Id;
            interview.SurveyId = surveys[rnd.Next(0,surveys.Count)].Id;
            if (!oneHasNoAnswers)
            {
                oneHasNoAnswers = true;
                continue;
            }
            interview.Results = new List<Result>()
            {
                new Result()
                {
                    AnswerId = survay.SurveyQuestionNumbers.Where(x => x.Number == 1).FirstOrDefault().Question.Answers.ElementAt(0).Id
                },
                new Result()
                {
                    AnswerId = survay.SurveyQuestionNumbers.Where(x => x.Number == 2).FirstOrDefault().Question.Answers.ElementAt(1).Id
                }
            };
        }
        await context.Interviews.AddRangeAsync(interviews);

        await context.SaveChangesAsync();
    }
}