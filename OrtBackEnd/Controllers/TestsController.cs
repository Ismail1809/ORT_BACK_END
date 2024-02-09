using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrtBackEnd.DatabaseContext;
using OrtBackEnd.Models;

namespace OrtBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly QuestionsDb _context;

        public TestsController(QuestionsDb context)
        {
            _context = context;
        }

        // GET: api/Tests
        [Route("GetTests")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetTests()
        {
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("GetTests/{id}")]
        public async Task<ActionResult<Question>> GetTest(int id)
        {
            var tests = await _context.Questions.FindAsync(id);

            if (tests == null)
            {
                return NotFound();
            }

            return tests;
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("UpdateTest")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTests(int id, Question tests)
        {
            if (id != tests.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(tests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("AddQuestion")]
        [HttpPost()]
        public async Task<ActionResult<Question>> AddQuestion([FromBody] Question tests)
        {
            _context.Questions.Add(tests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTests", new { id = tests.QuestionId }, tests);
        }


        [HttpPost("CheckQuizResults")]
        public async Task<ActionResult<Answer>> CheckQuizResults([FromBody] List<Answer> questionResponses)
        {
            if (questionResponses == null)
            {
                return BadRequest("The question responses are null.");
            }

            int correctAnswersCount = 0;

            foreach (var response in questionResponses)
            {
                // Assuming you have a way to identify which question each response belongs to, e.g., a QuestionId property on QuestionResponse
                var correctAnswer = await _context.Questions
                    .Where(t => t.QuestionId == response.QuestionId) // This assumes QuestionResponse includes a QuestionId property
                    .Select(t => t.CorrectAnswer)
                    .FirstOrDefaultAsync();

                if (response.UserAnswer?.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase) == true)
                {
                    correctAnswersCount++;
                }
            }

            return Ok(correctAnswersCount);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTests(int id)
        {
            var tests = await _context.Questions.FindAsync(id);
            if (tests == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(tests);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    

        private bool TestsExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }

}
