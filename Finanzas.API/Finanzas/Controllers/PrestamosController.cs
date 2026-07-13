using Finanzas.Domain.DTO;
using Finanzas.Interfaces.Reposritory;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController(IPrestamosRepository _prestamosRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamosDto>>> GetPrestamos()
        {
            return await _prestamosRepository.GetAllPrestamosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamosDto?>> GetPrestamo(int id)
        {
            var prestamo = await _prestamosRepository.GetPrestamoById(id);
            if (prestamo == null) return NotFound("No fue posible encontrar el préstamo");
            return prestamo;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostPrestamo(PrestamosDto prestamosDto)
        {
            await _prestamosRepository.PostPrestamoAsync(prestamosDto);
            return CreatedAtAction("GetPrestamo", new { id = prestamosDto.PrestamoId }, prestamosDto);
        }
    }
}
