using Finanzas.Domain.DTO;

namespace Finanzas.Interfaces.Reposritory;

public interface IPrestamosRepository
{
    public Task<List<PrestamosDto>> GetAllPrestamosAsync();
    public Task<bool> PostPrestamoAsync(PrestamosDto prestamo);
    public Task<PrestamosDto?> GetPrestamoById(int prestamoId);
}
