using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using kanban_backed.Business.Interfaces;
using kanban_backend.DTOs;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace kanban_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginController(ILoginService loginService, IJwtTokenService jwtTokenService)
    {
        _loginService = loginService;
        _jwtTokenService = jwtTokenService;
    }
        
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var isValid = await _loginService.Login(model.Login, model.Senha);

        if(isValid)
        {
            return Ok(_jwtTokenService.GenerateToken(model.Login));
        }
        return Unauthorized();
    }

}

