using NewTest.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace NewTest.Context.Context.Configuration
{
    public static class AnswersContextConfiguration
    {
        public static void ConfigureAnswers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().Property(x => x.Text).IsRequired();
            modelBuilder.Entity<Answer>().HasOne(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
