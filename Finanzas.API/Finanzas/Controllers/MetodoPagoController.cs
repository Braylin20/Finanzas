using Finanzas.Domain.DTO;
using Finanzas.Interfaces.Reposritory;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetodoPagoController(IMetodoPagoReporitory _repo) : ControllerBase
{
    // GET: api/MetodoPago
    [HttpGet]
    public async Task<ActionResult<List<MetodoPagoDto>>> Get()
    {
        return await _repo.GetAllMetodosAsync();
    }
}
