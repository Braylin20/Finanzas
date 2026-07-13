using Finanzas.Domain.DTO;
using Finanzas.Interfaces.Reposritory;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController(IGastosRepository _gastosRepository) : ControllerBase
    {

        // GET: api/Gastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastosDto>>> GetGastos()
        {
            return await _gastosRepository.GetAllGastosAsync();
        }

        // GET: api/Gastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GastosDto?>> GetGastos(int id)
        {
            var gastos = await _gastosRepository.GetGastoById(id);

            if (gastos == null)
            {
                return NotFound("No fue posible encontrar el gasto");
            }

            return gastos;
        }

        //// PUT: api/Gastos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{gastoId}")]
        public async Task<ActionResult<bool>> PutGastos(GastosDto gastos, int gastoId)
        {
            var result = await _gastosRepository.PutGasto(gastos, gastoId);
            if(!result) return NotFound();

            return Ok(result);
        }

        // POST: api/Gastos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostGastos(GastosDto gastosDto)
        {
            await _gastosRepository.PostGastoAsync(gastosDto);

            return CreatedAtAction("GetGastos", new { id = gastosDto.GastoId }, gastosDto);
        }

        // DELETE: api/Gastos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGastos(int id)
        {
            var result = await _gastosRepository.DeleteGasto(id);
            if(!result) return NotFound();
           
            return Ok(result);
        }

        //private bool GastosExists(int id)
        //{
        //    return _context.Gastos.Any(e => e.GastoId == id);
        //}
    }
}
