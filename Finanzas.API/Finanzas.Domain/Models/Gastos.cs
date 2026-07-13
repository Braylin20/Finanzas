using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas.Domain.Models;

public class Gastos
{
    [Key]
    public int GastoId { get; set; }
    public int? TipoGastoId { get; set; }
    public int? MetodoPagoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }
    [ForeignKey(nameof(TipoGastoId))]
    public TipoGastos? TipoGasto { get; set; }
    [ForeignKey(nameof(MetodoPagoId))]
    public MetodoPagos? MetodoPago { get; set; }
}
