using Finanzas.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas.Domain.DTO;

public class GastosDto
{
    public int GastoId { get; set; }
    public int TipoGastoId { get; set; }
    public int MetodoPagoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }
    public TipoGastosDto? TipoGastosDto { get; set; } = null!;
    public MetodoPagoDto? MetodoPago { get; set; }

}
