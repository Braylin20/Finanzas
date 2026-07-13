using Finanzas.Domain.DTO;
using Finanzas.Interfaces.Reposritory;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoGastosController(ITipoGastosReporitory _tipoRepo) : ControllerBase
{
    // GET: api/TipoGastos
    [HttpGet]
    public async Task<ActionResult<List<TipoGastosDto>>> Get()
    {
        return await _tipoRepo.GetAllGastosAsync();
    }

    // GET: api/TipoGastos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TipoGastosDto?>> Get(int id)
    {
        var tipo = await _tipoRepo.GetTipoGastoById(id);

        if (tipo == null)
        {
            return NotFound();
        }

        return tipo;
    }
}
