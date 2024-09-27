using Microsoft.EntityFrameworkCore;
using NewTest.Context.Entities;

namespace NewTest.Context.Context.Configuration
{
    public static class InterviewsContextConfiguration
    {
        public static void ConfigureInterviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interview>().ToTable("interviews");
            modelBuilder.Entity<Interview>().Property(x => x.PersonName).IsRequired();
            modelBuilder.Entity<Interview>().HasOne(x => x.Survey).WithMany(x => x.Interviews).HasForeignKey(x => x.SurveyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
