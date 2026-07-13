using Finanzas.Data.Dal;
using Finanzas.Domain.DTO;
using Finanzas.Interfaces.Reposritory;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Repository;

    public class MetodoPagoRepository(Contexto _contexto) : IMetodoPagoReporitory
    {
    public async Task<List<MetodoPagoDto>> GetAllMetodosAsync()
    {
        return await _contexto.MetodosPago
            .Select(m => new MetodoPagoDto
            {
                MetodoPagoId = m.MetodoPagoId,
                Descripcion = m.Descripcion
            }).ToListAsync();
    }
}
