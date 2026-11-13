using Microsoft.AspNetCore.Mvc;

namespace EmpleoLocalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleosController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string? texto)
    {
        var empleos = new[]
        {
            new { Id = 1, Titulo = "Cajero/a", Lugar = "Usulután" },
            new { Id = 2, Titulo = "Mesero/a", Lugar = "Usulután" }
        };

        if (!string.IsNullOrWhiteSpace(texto))
        {
            empleos = empleos
                .Where(e => e.Titulo.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        return Ok(empleos);
    }
}