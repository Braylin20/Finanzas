using Finanzas.Domain.DTO;

namespace Finanzas.Interfaces.Reposritory;

public interface IGastosRepository
{
    public Task<List<GastosDto>> GetAllGastosAsync();
    public Task<bool> PostGastoAsync(GastosDto gasto);
    public Task<GastosDto?> GetGastoById(int gastoId);
    public Task<bool> PutGasto(GastosDto gastoDto, int gastoId);
    public Task<bool> DeleteGasto(int gastoId);
}
