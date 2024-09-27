using Microsoft.EntityFrameworkCore;
using NewTest.Context.Entities;

namespace NewTest.Context.Context.Configuration
{
    public static class ResultsContextConfiguration
    {
        public static void ConfigureResults (this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().ToTable("results");
            modelBuilder.Entity<Result>().HasOne(x => x.Interview).WithMany(x => x.Results).HasForeignKey(x => x.InterviewId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Result>().HasOne(x => x.Answer).WithMany(x => x.Results).HasForeignKey(x => x.AnswerId).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Result>().HasIndex(e => new { e.InterviewId, e.AnswerId}).IsUnique();
        }
    }
}
