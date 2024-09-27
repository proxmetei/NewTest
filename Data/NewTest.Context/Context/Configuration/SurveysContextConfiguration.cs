using Microsoft.EntityFrameworkCore;
using NewTest.Context.Entities;

namespace NewTest.Context.Context.Configuration
{
    public static class SurveysContextConfiguration
    {
        public static void ConfigureSurveys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().ToTable("surveys");
            modelBuilder.Entity<Survey>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Survey>().HasMany(x => x.Questions).WithMany(x => x.Surveys).UsingEntity<SurveyQuestionNumber>(
                j => j
                    .HasOne(x => x.Question)
                    .WithMany(x => x.SurveyQuestionNumbers)
                    .HasForeignKey(x => x.QuestionId),
                j => j
                    .HasOne(x => x.Survey)
                    .WithMany(x => x.SurveyQuestionNumbers)
                    .HasForeignKey(x => x.SurveyId),
                j =>
                {
                    j.Property(x => x.Number).IsRequired();
                    j.HasKey(t => new { t.SurveyId, t.QuestionId });
                    j.ToTable("survey_question");
                });
            modelBuilder.Entity<Survey>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
