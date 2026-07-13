using Finanzas.Data.Dal;
using Finanzas.Domain.DTO;
using Finanzas.Interfaces.Reposritory;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Repository
{
    public class TipoGastosRepository(Contexto _contexto) : ITipoGastosReporitory
    {
        public async Task<List<TipoGastosDto>> GetAllGastosAsync()
        {
            return await _contexto.TiposGastos.Select(tg => new TipoGastosDto
            {
                Descripcion = tg.Descripcion,
                TipoGastoId = tg.TipoGastoId
            }).ToListAsync();
        }

        public async Task<TipoGastosDto?> GetTipoGastoById(int tipoGastoId)
        {
            return await _contexto.TiposGastos
                .Where(t => t.TipoGastoId == tipoGastoId)
                .Select(tg => new TipoGastosDto
                {
                    Descripcion = tg.Descripcion,
                    TipoGastoId = tg.TipoGastoId
                })
                .FirstOrDefaultAsync();
        }
    }
}
