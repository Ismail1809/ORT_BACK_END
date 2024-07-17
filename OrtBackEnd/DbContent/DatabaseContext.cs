using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OrtBackEnd.Models;

namespace OrtBackEnd.DbContent
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DatabaseContext() { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<TestAttempt> TestAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(k => k.TestId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.QuestionOptions)
                .WithOne(q => q.Question)
                .HasForeignKey(k => k.QuestionId);


        }
    }
}
