using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrtBackEnd.DatabaseContext;
using OrtBackEnd.Models;
using OrtBackEnd.ModelsDTO;
using AutoMapper;
using OrtBackEnd.Mappers;

namespace OrtBackEnd.Controllers
{

    public class AddQuestionResponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
    }

    [Route("[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly QuestionsDb _context;
        private readonly IMapper _mapper;

        public TestsController(QuestionsDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tests
        [Route("GetTests")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetTests()
        {
            var questions = await _context.Questions.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<QuestionModelDTO>>(questions));
        }

        // GET: api/Tests/5
        [HttpGet("GetTests/{id}")]
        public async Task<ActionResult<QuestionModel>> GetTest(int id)
        {
            var questions = await _context.Questions.FindAsync(id);

            if (questions == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<QuestionModelDTO>(questions));
        }


        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("AddQuestion")]
        [HttpPost()]
        public async Task<ActionResult<QuestionModel>> AddQuestion([FromBody] QuestionModel question)
        {
            var questionModelX = new QuestionModel
            {
                QuestionText = question.QuestionText,
                CorrectAnswer = new CorrectAnswerModel { AnswerText = question.CorrectAnswer.AnswerText }
            };

            questionModelX.QuestionAnswers = new List<QuestionAnswerModel>();

            if (question.QuestionAnswers is null) throw new ArgumentNullException(nameof(QuestionModel.QuestionAnswers));

            foreach (var answer in question.QuestionAnswers)
            {
                questionModelX.QuestionAnswers.Add(answer);
            }

            await _context.Questions.AddAsync(questionModelX);

            await _context.SaveChangesAsync();

            var response = new AddQuestionResponse { QuestionId = questionModelX.QuestionId, QuestionText = questionModelX.QuestionText };

            return Ok(response);
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
                    .Select(t => t.CorrectAnswer.AnswerText)
                    .FirstOrDefaultAsync();

                if (response.UserAnswer?.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase) == true)
                {
                    correctAnswersCount++;
                }
            }

            return Ok(correctAnswersCount);
        }


        [Route("AddUser")]
        [HttpPost()]
        public async Task<ActionResult<QuestionModel>> AddUser([FromBody] User users)
        {
            if(users != null)
            {
                await _context.Users.AddAsync(users);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NoContent();
            }

            return Ok(users);
        }


        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("UpdateTest")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTests(int id, QuestionModel tests)
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


        // DELETE: api/Tests/5
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var test = await _context.Questions.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(test);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestsExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }

}
