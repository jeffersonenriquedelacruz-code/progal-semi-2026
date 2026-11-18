using Microsoft.AspNetCore.Mvc;

namespace EmpleoLocalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleosController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string? texto, string? departamento)
    {
        var empleos = new[]
        {
            new { Id = 1, Titulo = "Cajero/a", Lugar = "Usulután", Departamento = "Usulután" },
            new { Id = 2, Titulo = "Mesero/a", Lugar = "Usulután", Departamento = "Usulután" },
            new { Id = 3, Titulo = "Auxiliar administrativo", Lugar = "San Vicente", Departamento = "San Vicente" },
            new { Id = 4, Titulo = "Vendedor/a", Lugar = "San Vicente", Departamento = "San Vicente" },
            new { Id = 5, Titulo = "Mecánico automotriz", Lugar = "San Miguel", Departamento = "San Miguel" }
        };

        if (!string.IsNullOrWhiteSpace(texto))
        {
            empleos = empleos
                .Where(e => e.Titulo.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        if (!string.IsNullOrWhiteSpace(departamento))
        {
            empleos = empleos
                .Where(e => e.Departamento.Equals(departamento, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        return Ok(empleos);
    }
}