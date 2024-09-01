using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.DTOs;
using WebApplication13.Hasher;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USerController : ControllerBase
    {
        private readonly MyDbContext _Db;

        public USerController(MyDbContext db)
        {

            _Db = db;
        }

        [HttpPost("register")] 
        public async Task<IActionResult> Register([FromForm] UserDTO model)
        {
            byte[] passwordHash, passwordSalt;
            PasswordHasher.CreatePassword(model.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password=model.Password,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _Db.Users.AddAsync(user);
            await _Db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserDTO model)
        {
            var user = await _Db.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
            if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            // Generate a token or return a success response
            return Ok("User logged in successfully");
        }
    }
}
