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
            new { Id = 1, Titulo = "Cajero", Lugar = "Ahuachapán", Departamento = "Ahuachapán" },
            new { Id = 2, Titulo = "Vendedor", Lugar = "Ahuachapán", Departamento = "Ahuachapán" },

            new { Id = 3, Titulo = "Auxiliar administrativo", Lugar = "Santa Ana", Departamento = "Santa Ana" },
            new { Id = 4, Titulo = "Mesero", Lugar = "Santa Ana", Departamento = "Santa Ana" },

            new { Id = 5, Titulo = "Motorista", Lugar = "Sonsonate", Departamento = "Sonsonate" },
            new { Id = 6, Titulo = "Dependiente de tienda", Lugar = "Sonsonate", Departamento = "Sonsonate" },

            new { Id = 7, Titulo = "Agricultor", Lugar = "Chalatenango", Departamento = "Chalatenango" },
            new { Id = 8, Titulo = "Vendedor", Lugar = "Chalatenango", Departamento = "Chalatenango" },

            new { Id = 9, Titulo = "Mecánico automotriz", Lugar = "Santa Tecla", Departamento = "La Libertad" },
            new { Id = 10, Titulo = "Cocinero", Lugar = "La Libertad", Departamento = "La Libertad" },

            new { Id = 11, Titulo = "Programador", Lugar = "San Salvador", Departamento = "San Salvador" },
            new { Id = 12, Titulo = "Contador", Lugar = "San Salvador", Departamento = "San Salvador" },

            new { Id = 13, Titulo = "Cajero", Lugar = "Cojutepeque", Departamento = "Cuscatlán" },
            new { Id = 14, Titulo = "Auxiliar de bodega", Lugar = "Cuscatlán", Departamento = "Cuscatlán" },

            new { Id = 15, Titulo = "Motorista", Lugar = "Zacatecoluca", Departamento = "La Paz" },
            new { Id = 16, Titulo = "Vendedor", Lugar = "La Paz", Departamento = "La Paz" },

            new { Id = 17, Titulo = "Dependiente de tienda", Lugar = "Sensuntepeque", Departamento = "Cabañas" },
            new { Id = 18, Titulo = "Agricultor", Lugar = "Cabañas", Departamento = "Cabañas" },

            new { Id = 19, Titulo = "Auxiliar administrativo", Lugar = "San Vicente", Departamento = "San Vicente" },
            new { Id = 20, Titulo = "Mesero", Lugar = "San Vicente", Departamento = "San Vicente" },

            new { Id = 21, Titulo = "Mecánico automotriz", Lugar = "Usulután", Departamento = "Usulután" },
            new { Id = 22, Titulo = "Cajero", Lugar = "Usulután", Departamento = "Usulután" },

            new { Id = 23, Titulo = "Electricista", Lugar = "San Miguel", Departamento = "San Miguel" },
            new { Id = 24, Titulo = "Vendedor", Lugar = "San Miguel", Departamento = "San Miguel" },

            new { Id = 25, Titulo = "Agricultor", Lugar = "San Francisco Gotera", Departamento = "Morazán" },
            new { Id = 26, Titulo = "Motorista", Lugar = "Morazán", Departamento = "Morazán" },

            new { Id = 27, Titulo = "Mesero", Lugar = "La Unión", Departamento = "La Unión" },
            new { Id = 28, Titulo = "Pescador", Lugar = "La Unión", Departamento = "La Unión" }
        };

      
        if (!string.IsNullOrWhiteSpace(texto))
        {
            empleos = empleos
                .Where(e => e.Titulo.Contains(
                    texto,
                    StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

       
        if (!string.IsNullOrWhiteSpace(departamento))
        {
            empleos = empleos
                .Where(e => e.Departamento.Equals(
                    departamento,
                    StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        return Ok(empleos);
    }
}