using Finanzas.Data.Dal;
using Finanzas.Domain.DTO;
using Finanzas.Domain.Models;
using Finanzas.Interfaces.Reposritory;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Repository;

public class GastosRepository(Contexto _contexto) : IGastosRepository
{
    public async Task<bool> DeleteGasto(int gastoId)
    {
        var gasto = await _contexto.Gastos.FindAsync(gastoId);
        if (gasto is null)
            return false;

        _contexto.Gastos.Remove(gasto);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<GastosDto>> GetAllGastosAsync()
    {
        return await (
            from g in _contexto.Gastos
            join tg in _contexto.TiposGastos on g.TipoGastoId equals tg.TipoGastoId
            join mp in _contexto.MetodosPago on g.MetodoPagoId equals mp.MetodoPagoId
            orderby g.Fecha descending
            select new GastosDto
            {
                GastoId = g.GastoId,
                Descripcion = g.Descripcion,
                Monto = g.Monto,
                Fecha = g.Fecha,
                TipoGastoId = g.TipoGastoId ?? 0,
                MetodoPagoId = g.MetodoPagoId ?? 0,
                TipoGastosDto = new TipoGastosDto
                {
                    Descripcion = tg.Descripcion,
                    TipoGastoId = tg.TipoGastoId
                },
                MetodoPago = new MetodoPagoDto
                {
                    MetodoPagoId = mp.MetodoPagoId,
                    Descripcion = mp.Descripcion
                }
            }
            ).ToListAsync();
    }

    public async Task<GastosDto?> GetGastoById(int gastoId)
    {
        return await (
            from g in _contexto.Gastos
            join tg in _contexto.TiposGastos on g.TipoGastoId equals tg.TipoGastoId
            join mp in _contexto.MetodosPago on g.MetodoPagoId equals mp.MetodoPagoId
            where g.GastoId == gastoId

            select new GastosDto
            {
                GastoId = g.GastoId,
                Descripcion = g.Descripcion,
                Monto = g.Monto,
                Fecha = g.Fecha,
                TipoGastoId = g.TipoGastoId ?? 0,
                MetodoPagoId = g.MetodoPagoId ?? 0,
                TipoGastosDto = new TipoGastosDto
                {
                    TipoGastoId = tg.TipoGastoId
                },
                MetodoPago = new MetodoPagoDto
                {
                    MetodoPagoId = mp.MetodoPagoId
                }
            }
            ).FirstOrDefaultAsync();
    }

    public async Task<bool> PostGastoAsync(GastosDto gasto)
    {
        await _contexto.Gastos.AddAsync(new Gastos
        {
            Descripcion = gasto.Descripcion,
            Monto = gasto.Monto,
            Fecha = gasto.Fecha,
            TipoGastoId = gasto.TipoGastoId,
            MetodoPagoId = gasto.MetodoPagoId
        });
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> PutGasto(GastosDto gastoDto, int gastoId)
    {
        var gasto = await _contexto.Gastos.FindAsync(gastoId);
        if (gasto is null)
            return false;

        gasto.Descripcion = gastoDto.Descripcion;
        gasto.Monto = gastoDto.Monto;
        gasto.Fecha = gastoDto.Fecha;
        gasto.TipoGastoId = gastoDto.TipoGastoId;

        return await _contexto.SaveChangesAsync() > 0;
    }
}
