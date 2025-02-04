using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        var token = _authService.Authenticate(loginModel.Username, loginModel.Password);
        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
}

