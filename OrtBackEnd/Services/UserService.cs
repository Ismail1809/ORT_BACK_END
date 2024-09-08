using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrtBackEnd.Contracts;
using OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges;
using OrtBackEnd.DbContent;
using OrtBackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrtBackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly DatabaseContext _context;
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public UserService(IConfiguration configuration, DatabaseContext context)
        {
            _configuration = configuration;
            _context = context;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper");
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            return users;
        }

        public async Task UpdateAsync(User existingUser)
        {

            await _userRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public string Login(UserLoginRequest userRequest)
        {
            var LoginUser = _context.Users.SingleOrDefault(x => x.Username == userRequest.Username);

            if (LoginUser == null)
            {
                return null;
            }

            var passwordHash = PasswordHasher.ComputeHash(userRequest.Password, LoginUser.PasswordSalt, _pepper, _iteration);
            if (LoginUser.PasswordHash != passwordHash)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userRequest.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }

        public async Task<UserResponse> RegisterAsync(UserRegisterRequest userRequest)
        {
            var isRegisteredUser = _context.Users.SingleOrDefault(x => x.Username == userRequest.Username);

            if (isRegisteredUser != null)
            {
                return null;
            }

            var user = new User
            {
                Username = userRequest.Username,
                Email = userRequest.Email,
                PasswordSalt = PasswordHasher.GenerateSalt(),
                Role = userRequest.Username == "Admin" ? "Admin": "User",
            };
            
            user.PasswordHash = PasswordHasher.ComputeHash(userRequest.Password, user.PasswordSalt, _pepper, _iteration);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var payload = new UserResponse
            {
                Username = userRequest.Username,
                Email = userRequest.Email,
            };

            return payload;
        }

    }
}
