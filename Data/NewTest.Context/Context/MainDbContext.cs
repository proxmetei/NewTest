namespace NewTest.Context;

using NewTest.Context.Entities;
using Microsoft.EntityFrameworkCore;
using NewTest.Context.Context.Configuration;

public class MainDbContext : DbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureAnswers();
        modelBuilder.ConfigureQuestions();
        modelBuilder.ConfigureSurveys();
        modelBuilder.ConfigureResults();
        modelBuilder.ConfigureInterviews();
    }
}
