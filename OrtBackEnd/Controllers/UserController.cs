using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using OrtBackEnd.API;
using OrtBackEnd.Contracts;
using OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges;
using OrtBackEnd.DatabaseContext;
using OrtBackEnd.Models;

namespace OrtBackEnd.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            if(users == null)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            var payload = _mapper.Map<IEnumerable<UserResponse>>(users);
            return base.Ok(new ApiResponse<IEnumerable<UserResponse>>(ResultCode.Success, ResultDescription.Success, payload));
        }

        // GET: api/UserManagement/5
        [HttpGet("me")]
        public async Task<ActionResult> GetUser([FromQuery] int id)
        {
            User user = await _userRepository.GetById(id);

            if (user == null)
            {
                // return NotFound(); // http.404 (1. endpoint not found, 2. user not found)

                return base.BadRequest(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            return base.Ok(new ApiResponse<UserResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<UserResponse>(user)));
        }

        // PUT: api/UserManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("me")]
        public async Task<ActionResult> PutUser([FromQuery] int id,[FromBody] UserUpdateRequest user)
        {
            User existingUser = await _userRepository.GetById(id);

            if (user == null || existingUser == null)
            {
                return base.Ok(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                _mapper.Map(user, existingUser);
                await _userRepository.UpdateAsync(existingUser);

                return base.Ok(new ApiResponse<UserResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<UserResponse>(existingUser)));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }
        }

        // POST: api/UserManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] User user)
        {
            if(user == null)
            {
                return NoContent();
            }
            try
            {
                
                var payload = await _userRepository.AddAsync(user);
                return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.Success));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NoContent, ResultDescription.NoContent, ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody]User user)
        {
            if (user == null)
            {
                return NoContent();
            }
            try
            {
                User payload = await _userRepository.AddAsync(user);

                return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.Success));
            }
            catch (Exception ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NoContent, ResultDescription.NoContent));
            }
        }

        // DELETE: api/UserManagement/5
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromQuery] int id)
        {
            User user = await _userRepository.GetById(id);
            if (user == null)
            {
                return base.Ok(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                await _userRepository.DeleteAsync(id);
            }
            catch(Exception ex)
            {
                return base.StatusCode((int)HttpStatusCode.InternalServerError,new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }

            return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.NoContent, null));
        }
    }
}
