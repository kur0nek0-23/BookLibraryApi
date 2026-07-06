// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Data;
using BookLibraryApi.Dtos;
using BookLibraryApi.Models;
using BookLibraryApi.Services;

namespace BookLibraryApi.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.User.AnyAsync(u => u.Username == dto.Username))
                return BadRequest("Username already taken.");

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid username or password.");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }
    }
}