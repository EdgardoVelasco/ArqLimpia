// Controllers/ValoresController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValoresController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult ObtenerValores()
    {
        var valores = new[] { "Valor1", "Valor2", "Valor3" };
        return Ok(valores);
    }
}