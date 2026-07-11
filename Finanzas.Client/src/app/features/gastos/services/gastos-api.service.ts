import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/enviorenments';
import { Gasto } from '../../../interfaces/Gasto';
import { Observable } from 'rxjs';
import { MetodoPago } from '../../../interfaces/MetodoPago';
import { TipoGastos } from '../../../interfaces/TipoGastos';

@Injectable({
  providedIn: 'root',
})
export class GastosApiService {
  private readonly httpClient: HttpClient = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getGastos(): Observable<Gasto[]> {
    return this.httpClient.get<Gasto[]>(`${this.apiUrl}/gastos`);
  }

  getGastoById(gastoId: number): Observable<Gasto> {
    return this.httpClient.get<Gasto>(`${this.apiUrl}/gastos/${gastoId}`);
  }

  postGasto(gasto: Gasto): Observable<boolean> {
    return this.httpClient.post<boolean>(`${this.apiUrl}/gastos`, gasto);
  }

  putGasto(gasto:Gasto): Observable<boolean>{
    return this.httpClient.put<boolean>(`${this.apiUrl}/gastos/${gasto.gastoId}`, gasto);
  }

  deleteGasto(gastoId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.apiUrl}/gastos/${gastoId}`);
  }
  getMetodoPagos(): Observable<MetodoPago[]> {
    return this.httpClient.get<MetodoPago[]>(`${environment.apiUrl}/metodoPago`);
  }
  public getTipoGastos(): Observable<TipoGastos[]> {
    return this.httpClient.get<TipoGastos[]>(`${environment.apiUrl}/tipogastos`);
  }
  public getTipoGastoById(tipoGastoId: number): Observable<TipoGastos> {
    return this.httpClient.get<TipoGastos>(`${environment.apiUrl}/tipogastos/${tipoGastoId}`);
  }

}
