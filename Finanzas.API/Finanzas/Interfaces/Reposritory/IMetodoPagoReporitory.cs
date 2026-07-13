using Finanzas.Domain.DTO;

namespace Finanzas.Interfaces.Reposritory
{
    public interface IMetodoPagoReporitory
    {
        public Task<List<MetodoPagoDto>> GetAllMetodosAsync();
    }
}
