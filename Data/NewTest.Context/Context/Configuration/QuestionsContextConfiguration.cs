using NewTest.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace NewTest.Context.Context.Configuration
{
    public static class QuestionsContextConfiguration
    {
        public static void ConfigureQuestions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<Question>().Property(x => x.Text).IsRequired();
        }
    }
}
