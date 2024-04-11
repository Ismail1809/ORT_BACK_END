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
using OrtBackEnd.DatabaseContext;
using OrtBackEnd.Models;
using OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges;
using OrtBackEnd.Repositories;

namespace OrtBackEnd.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestAttemptsController : ControllerBase
    {
        private readonly ITestAttemptsRepository _testAttemptsRepository;
        private readonly IMapper _mapper;

        public TestAttemptsController(ITestAttemptsRepository testAttemptsRepository, IMapper mapper)
        {
            _testAttemptsRepository = testAttemptsRepository ?? throw new ArgumentNullException(nameof(testAttemptsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(testAttemptsRepository));
        }


        [HttpGet]
        public async Task<ActionResult> GetSpecificAttempts([FromQuery] int userId)
        {
            var attempt = await _testAttemptsRepository.GetByUserId(userId);

            if (attempt == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            return base.Ok(new ApiResponse<IEnumerable<TestAttemptResponse>>(ResultCode.Success, ResultDescription.Success, _mapper.Map<IEnumerable<TestAttemptResponse>>(attempt)));
        }


        [HttpGet]
        public async Task<ActionResult> GetSpecificTestAttempt([FromQuery] int id)
        {
            var attempt = await _testAttemptsRepository.GetById(id);

            if (attempt == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            return base.Ok(new ApiResponse<TestAttemptResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestAttemptResponse>(attempt)));
        }


        [HttpPut]
        public async Task<ActionResult> FinalizeTestAttempt([FromQuery] int id, [FromBody] TestAttemptsUpdateRequest testAttempt)
        {
            TestAttempt existingAttempt = await _testAttemptsRepository.GetById(id);

            if (testAttempt == null || existingAttempt == null)
            {
                return base.Ok(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                _mapper.Map(testAttempt, existingAttempt);
                await _testAttemptsRepository.UpdateAsync(existingAttempt);
                return base.Ok(new ApiResponse<TestAttemptResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestAttemptResponse>(existingAttempt)));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }
        }


        [HttpPost]
        public async Task<ActionResult> StartTestAttempt([FromBody]TestAttemptsCreateRequest testAttempt)
        {
            var newTest = await _testAttemptsRepository.AddAsync(_mapper.Map<TestAttempt>(testAttempt));

            return base.Ok(new ApiResponse<TestAttemptResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<TestAttemptResponse>(newTest)));
        }
    }
}
