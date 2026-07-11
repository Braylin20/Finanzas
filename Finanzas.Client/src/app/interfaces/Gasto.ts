import { TipoGastos } from './TipoGastos';
import { MetodoPago } from './MetodoPago';

export interface Gasto {
  gastoId?: number;
  tipoGastoId?: number;
  metodoPagoId?: number;
  descripcion: string;
  monto: number;
  fecha: string;
  tipoGastosDto: TipoGastos;
  metodoPago: MetodoPago;
}
