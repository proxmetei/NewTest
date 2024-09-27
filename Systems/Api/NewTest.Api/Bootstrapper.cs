namespace NewTest.Api;

using NewTest.Services.Settings;
using NewTest.Services.Logger;
using NewTest.Services.Questions;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration = null)
    {
        services
            .AddMainSettings()
            .AddAppLogger()
            .AddQuestionService();

        return services;
    }
}
