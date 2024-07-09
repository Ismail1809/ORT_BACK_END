using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Controllers.RequestsAndResponses.QuestionOptionExchanges;
using OrtBackEnd.Models;

namespace OrtBackEnd.DatabaseContext
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
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

            //modelBuilder.Entity<QuestionAnswerModel>()
            //    .HasOne(c => c.QuestionModel)
            //    .WithMany(u => u.QuestionAnswers)
            //    .HasForeignKey(c => c.QuestionId)
            //    .IsRequired();

            //modelBuilder.Entity<CorrectAnswerModel>()
            //    .HasOne(c => c.QuestionModel)
            //    .WithOne(u => u.CorrectAnswer)
            //    .HasForeignKey<CorrectAnswerModel>(c => c.QuestionId)
            //    .IsRequired();

            //modelBuilder.Entity<QuestionModel>()
            //    .HasMany(q => q.QuestionAnswers)
            //    .WithOne(q => q.QuestionModel)
            //    .HasForeignKey(k => k.QuestionId);

            //modelBuilder.Entity<QuestionModel>()
            //    .HasOne(q => q.CorrectAnswer)
            //    .WithOne(q => q.QuestionModel)
            //    .HasForeignKey<CorrectAnswerModel>(q => q.QuestionId);

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
