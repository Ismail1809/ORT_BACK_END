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

        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>().HasData(new Question() {QuestionId = 1, QuestionText = "Question1", AnswerA = "A", AnswerB = "B", AnswerC = "C", AnswerD = "D"});
            
        }
    }
}
