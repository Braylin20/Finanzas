import { Injectable, signal } from '@angular/core';
import { Gasto } from '../../../interfaces/Gasto';

@Injectable({
  providedIn: 'root',
})
export class GastosBusinessService {
  calcularCantidadTotalGastos(gastos: Gasto[]) {
    return gastos.reduce((cantidad) => cantidad + 1, 0);
  }

  calcularMontoTotalGastado(gastos: Gasto[]) {
    return gastos.reduce((total, gasto) => total + gasto.monto, 0);
  }

  calcularTotalGastosMes(gastos: Gasto[]) {
    const mesActual = new Date().getMonth();
    const anioActual = new Date().getFullYear();

    return gastos
      .filter((gasto) => {
        const fechaGasto = new Date(gasto.fecha);
        return fechaGasto.getMonth() === mesActual && fechaGasto.getFullYear() === anioActual;
      })
      .reduce((total, gasto) => total + gasto.monto, 0);
  }

  calcularTotalGastosHoy(gastos: Gasto[]) {
    const hoy = new Date();

    return gastos
      .filter((gasto) => {
        const fechaGasto = new Date(gasto.fecha);
        return (
          fechaGasto.getDay() === hoy.getDate() &&
          fechaGasto.getMonth() === hoy.getMonth() &&
          fechaGasto.getFullYear() === hoy.getFullYear()
        );
      })
      .reduce((total, gasto) => total + gasto.monto, 0);
  }
}
