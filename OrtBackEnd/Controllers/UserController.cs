using System.ComponentModel.DataAnnotations;
using System.Net;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrtBackEnd.API;
using OrtBackEnd.Contracts;
using OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges;
using OrtBackEnd.Models;
using OrtBackEnd.Services;

namespace OrtBackEnd.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

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
            var user = await _userService.GetUser(id);

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
            var existingUser = await _userService.GetUser(id);

            if (user == null || existingUser == null)
            {
                return base.Ok(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                _mapper.Map(user, existingUser);
                await _userService.UpdateAsync(existingUser);

                return base.Ok(new ApiResponse<UserResponse>(ResultCode.Success, ResultDescription.Success, _mapper.Map<UserResponse>(existingUser)));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }
        }

        // POST: api/UserManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegisterRequest user)
        {
            try
            {
                var response = await _userService.RegisterAsync(user);
                if (response == null)
                {
                    return base.Ok(new ApiResponse<object>(ResultCode.NoContent, ResultDescription.NoContent, "Username or password did not match."));
                }
                return base.Ok(new ApiResponse<UserResponse>(ResultCode.Success, ResultDescription.Success, response));
            }
            catch (ValidationException ex)
            {
                return base.BadRequest(new ApiResponse<object>(ResultCode.NoContent, ResultDescription.NoContent, "N ."));
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser([FromBody]UserLoginRequest user)
        {
            var token = _userService.Login(user);
            if (token == null || token == string.Empty)
            {
                return base.BadRequest(new ApiResponse<object>( ResultCode.NotFound, ResultDescription.NotFound, "UserName or Password is incorrect" ));
            }
            return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.Success, token));
        }

        // DELETE: api/UserManagement/5
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromQuery] int id)
        {
            User user = await _userService.GetUser(id);
            if (user == null)
            {
                return base.Ok(new ApiResponse<object>(ResultCode.NotFound, ResultDescription.NotFound));
            }

            try
            {
                await _userService.DeleteAsync(id);
            }
            catch(Exception ex)
            {
                return base.StatusCode((int)HttpStatusCode.InternalServerError,new ApiResponse<object>(ResultCode.ValidationException, ex.Message));
            }

            return base.Ok(new ApiResponse<object>(ResultCode.Success, ResultDescription.NoContent, null));
        }
    }
}
