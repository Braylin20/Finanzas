using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas.Domain.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }
}
