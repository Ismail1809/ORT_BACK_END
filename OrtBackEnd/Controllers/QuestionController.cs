using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrtBackEnd.API;
using OrtBackEnd.Contracts;
using OrtBackEnd.Controllers.RequestsAndResponses.QuestionExchanges;
using OrtBackEnd.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OrtBackEnd.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(questionRepository)); 
        }


        [HttpGet]
        public async Task<ActionResult> GetQuestions([FromQuery] int testId)
        {
            var question = await _questionRepository.GetByTestId(testId);

            if (question == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            return base.Ok(new ApiResponse<List<Question>>(ResultCode.Success, ResultDescription.Success, question));
        }

        [HttpPut]
        public async Task<ActionResult> PutQuestion([FromQuery]int id, [FromBody]QuestionUpdateRequest question)
        {
            Question existingQuestion = await _questionRepository.GetById(id);

            if (question == null || existingQuestion == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                _mapper.Map(question, existingQuestion);
                await _questionRepository.UpdateAsync(existingQuestion);
                return base.Ok(new ApiResponse<Question>(ResultCode.Success, ResultDescription.Success, existingQuestion));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }
        }

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> CreateQuestion([FromBody]QuestionCreateRequest question)
        {
            var newTest = await _questionRepository.AddAsync(_mapper.Map<Question>(question));

            return base.Ok(new ApiResponse<Question>(ResultCode.Success, ResultDescription.Success, newTest));
        }

        // DELETE: api/Questions/5
        [HttpDelete]
        public async Task<ActionResult> DeleteQuestion([FromQuery] int id)
        {
            Question question = await _questionRepository.GetById(id);
            if (question == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                _questionRepository.DeleteAsync(id);

                return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.Success));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }
        }
    }
}
