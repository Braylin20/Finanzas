using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas.Domain.DTO;

public class PrestamosDto
{
    public int PrestamoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }
}
