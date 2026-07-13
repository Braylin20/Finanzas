using System.ComponentModel.DataAnnotations;

namespace Finanzas.Domain.Models;

public class MetodoPagos
{
    [Key]
    public int MetodoPagoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
}
