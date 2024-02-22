using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Models;

namespace OrtBackEnd.DatabaseContext
{
    public class QuestionsDb: DbContext
    {
        public QuestionsDb(DbContextOptions<QuestionsDb> options): base(options)
        {
        } 

        public QuestionsDb() { }

        public virtual DbSet<QuestionModel> Questions { get; set; }
        public virtual DbSet<QuestionAnswerModel> QuestionAnswers { get; set; }
        public virtual DbSet<CorrectAnswerModel> CorrectAnswers { get; set; }


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

            modelBuilder.Entity<QuestionModel>()
                .HasMany(q => q.QuestionAnswers)
                .WithOne(q => q.QuestionModel)
                .HasForeignKey(k => k.QuestionId);

            modelBuilder.Entity<QuestionModel>()
                .HasOne(q => q.CorrectAnswer)
                .WithOne(q => q.QuestionModel)
                .HasForeignKey<CorrectAnswerModel>(q => q.QuestionId);






        }
    }
}
