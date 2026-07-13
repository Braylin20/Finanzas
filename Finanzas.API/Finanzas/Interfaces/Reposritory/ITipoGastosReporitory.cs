using Finanzas.Domain.DTO;

namespace Finanzas.Interfaces.Reposritory
{
    public interface ITipoGastosReporitory
    {
        public Task<List<TipoGastosDto>> GetAllGastosAsync();
        public Task<TipoGastosDto?> GetTipoGastoById(int tipoGastoId);
    }
}
