// Controllers/AuthController.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    // Clave secreta para firmar el token (debe ser la misma que en Program.cs)
    private readonly byte[] _key = Encoding.UTF8.GetBytes("EstaEsUnaClaveSecretaMuySeguraYDe32Caracteres!!");

    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] UsuarioModelo modelo)
    {
        var usuario = new IdentityUser { UserName = modelo.Email, Email = modelo.Email };
        var resultado = await _userManager.CreateAsync(usuario, modelo.Password);

        if (resultado.Succeeded)
        {
            return Ok(new { mensaje = "Usuario registrado exitosamente" });
        }
        else
        {
            return BadRequest(resultado.Errors);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioModelo modelo)
    {
        var usuario = await _userManager.FindByEmailAsync(modelo.Email);
        if (usuario != null && await _userManager.CheckPasswordAsync(usuario, modelo.Password))
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("id", usuario.Id!),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, usuario.Email!)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
        return Unauthorized(new { mensaje = "Credenciales inválidas" });
    }
}