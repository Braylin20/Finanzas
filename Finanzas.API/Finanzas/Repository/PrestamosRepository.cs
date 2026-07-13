using Finanzas.Data.Dal;
using Finanzas.Domain.DTO;
using Finanzas.Domain.Models;
using Finanzas.Interfaces.Reposritory;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Repository;

public class PrestamosRepository(Contexto _contexto) : IPrestamosRepository
{
    public async Task<List<PrestamosDto>> GetAllPrestamosAsync()
    {
        return await (
            from p in _contexto.Prestamos
            select new PrestamosDto
            {
                PrestamoId = p.PrestamoId,
                Descripcion = p.Descripcion,
                Monto = p.Monto,
                Fecha = p.Fecha
            }
            ).ToListAsync();
    }

    public async Task<PrestamosDto?> GetPrestamoById(int prestamoId)
    {
        return await (
            from p in _contexto.Prestamos
            where p.PrestamoId == prestamoId
            select new PrestamosDto
            {
                PrestamoId = p.PrestamoId,
                Descripcion = p.Descripcion,
                Monto = p.Monto,
                Fecha = p.Fecha
            }
            ).FirstOrDefaultAsync();
    }

    public async Task<bool> PostPrestamoAsync(PrestamosDto prestamo)
    {
        await _contexto.Prestamos.AddAsync(new Prestamos
        {
            Descripcion = prestamo.Descripcion,
            Monto = prestamo.Monto,
            Fecha = prestamo.Fecha
        });
        return await _contexto.SaveChangesAsync() > 0;
    }

}
