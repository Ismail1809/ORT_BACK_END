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
using OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges;
using OrtBackEnd.Controllers.RequestsAndResponses.TestExchanges;
using OrtBackEnd.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OrtBackEnd.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository ?? throw new ArgumentNullException(nameof(testRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/TestManagement
        [HttpGet]
        public async Task<ActionResult> GetTests()
        {
            var tests = await _testRepository.GetAllAsync();

            if (tests == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            var payload = _mapper.Map<IEnumerable<Test>>(tests);
            return base.Ok(new ApiResponse<IEnumerable<TestResponse>>(ResultCode.Success, ResultDescription.Success, _mapper.Map<IEnumerable<TestResponse>>(payload)));
        }

        // GET: api/TestManagement/5
        [HttpGet]
        public async Task<ActionResult> GetTest([FromQuery] int id)
        {
            var test = await _testRepository.GetById(id);

            if (test == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            return base.Ok(new ApiResponse<TestResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestResponse>(test)));
        }

        [HttpGet]
        public async Task<ActionResult> GetSpecificResult([FromQuery] int id)
        {
            var attempt = await _testRepository.GetResult(id);

            if (attempt == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            return base.Ok(new ApiResponse<List<TestAttemptResultResponse>>(ResultCode.Success, ResultDescription.Success, attempt));
        }


        [HttpGet("random")]
        public async Task<ActionResult> RandomTest()
        {
            var randomTest = await _testRepository.GetRandomTest();

            if (randomTest == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }



            return base.Ok(new ApiResponse<TestResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestResponse>(randomTest)));
        }

        // PUT: api/TestManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult> UpdateTest([FromQuery]int id, [FromBody]TestUpdateRequest test)
        {
            Test existingTest = await _testRepository.GetById(id);

            if (test == null || existingTest == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }
 

            try
            {
                _mapper.Map(test, existingTest);
                await _testRepository.UpdateAsync(existingTest);
                return base.Ok(new ApiResponse<TestResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestResponse>(existingTest)));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }

        }

        // POST: api/TestManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> CreateTest([FromBody] TestCreateRequest test)
        {
            var newTest = await _testRepository.AddAsync(_mapper.Map<Test>(test));

            return base.Ok(new ApiResponse<TestResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestResponse>(newTest)));

            //return CreatedAtAction("GetTest", new { id = test.TestId }, test);
        }

        // DELETE: api/TestManagement/5
        [HttpDelete]
        public async Task<ActionResult> DeleteTest([FromQuery] int id)
        {
            Test test = await _testRepository.GetById(id);
            if (test == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                _testRepository.DeleteAsync(id);

                return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.Success));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }
        }
    }
}
