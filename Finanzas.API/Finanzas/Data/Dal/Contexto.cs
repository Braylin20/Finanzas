using Finanzas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Dal
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<Gastos> Gastos { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<TipoGastos> TiposGastos { get; set; }
        public DbSet<MetodoPagos> MetodosPago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoGastos>().HasData(
                new TipoGastos { TipoGastoId = 1, Descripcion = "Alimentos" },
                new TipoGastos { TipoGastoId = 2, Descripcion = "Transporte" },
                new TipoGastos { TipoGastoId = 3, Descripcion = "Servicios" },
                new TipoGastos { TipoGastoId = 4, Descripcion = "Ocio" },
                new TipoGastos { TipoGastoId = 5, Descripcion = "Salud" },
                new TipoGastos { TipoGastoId = 6, Descripcion = "Gasolina" },
                new TipoGastos { TipoGastoId = 7, Descripcion = "Subscripciones" },
                new TipoGastos { TipoGastoId = 8, Descripcion = "Supermercado" }
            );

            modelBuilder.Entity<MetodoPagos>().HasData(
                new MetodoPagos { MetodoPagoId = 1, Descripcion = "Efectivo" },
                new MetodoPagos { MetodoPagoId = 2, Descripcion = "Tarjeta de crédito" },
                new MetodoPagos { MetodoPagoId = 3, Descripcion = "Tarjeta de débito" },
                new MetodoPagos { MetodoPagoId = 4, Descripcion = "Transferencia bancaria" },
                new MetodoPagos { MetodoPagoId = 7, Descripcion = "Otro" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
