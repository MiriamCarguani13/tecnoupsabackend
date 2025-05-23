using Microsoft.AspNetCore.Mvc;
using TecnoupsaBackend.Data;
using TecnoupsaBackend.Models;
using TecnoupsaBackend.Services;

namespace TecnoupsaBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(ApplicationDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User loginModel)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User registerModel)
    {
        if (_context.Users.Any(u => u.Email == registerModel.Email))
            return BadRequest("User already exists");

        _context.Users.Add(registerModel);
        _context.SaveChanges();
        return Ok();
    }
}