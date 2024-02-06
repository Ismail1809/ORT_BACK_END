using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Models;

namespace OrtBackEnd.DatabaseContext
{
    public class TestsDb: DbContext
    {
        public TestsDb(DbContextOptions<TestsDb> options): base(options)
        {
        } 

        public TestsDb() { }

        public virtual DbSet<Tests> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tests>().HasData(new Tests() { QuestionId  = 1, QuestionText = "Lorem Ipsum is simply dummy text of the printing?", AnswerA = "readable", AnswerB = "content", AnswerC = "making", AnswerD = "web page", CorrectAnswer = "content" });
            modelBuilder.Entity<Tests>().HasData(new Tests() { QuestionId = 2, QuestionText = "There are many variations of passages of Lorem Ipsum available", AnswerA = "middle", AnswerB = "Hampden-Sydney", AnswerC = "undoubtable", AnswerD = "reproduced", CorrectAnswer = "middle" });
            modelBuilder.Entity<Tests>().HasData(new Tests() { QuestionId = 3, QuestionText = "All the Lorem Ipsum generators on the Internet tend to repeat predefined", AnswerA = "generate", AnswerB = "Ipsum", AnswerC = "therefore", AnswerD = "repetition", CorrectAnswer = "Ipsum" });
            modelBuilder.Entity<Tests>().HasData(new Tests() { QuestionId = 4, QuestionText = "The standard chunk of Lorem Ipsum used since the", AnswerA = "reproduced", AnswerB = "exact", AnswerC = "accompanied", AnswerD = "versions", CorrectAnswer = "versions" });
            modelBuilder.Entity<Tests>().HasData(new Tests() { QuestionId = 5, QuestionText = "Lorem Ipsum comes from sections 1.10.32 and 1.10.33", AnswerA = "words", AnswerB = "standard", AnswerC = "popular", AnswerD = "repeat", CorrectAnswer = "generate" });
        }
    }
}
