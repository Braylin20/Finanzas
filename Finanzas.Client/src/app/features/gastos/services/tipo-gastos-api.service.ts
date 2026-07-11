import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoGastos } from '../../../interfaces/TipoGastos';
import { environment } from '../../../../environments/enviorenments';

@Injectable({
  providedIn: 'root',
})
export class TipoGastosApiService {
  httpClient = inject(HttpClient);

  public getTipoGastos(): Observable<TipoGastos[]> {
    return this.httpClient.get<TipoGastos[]>(`${environment.apiUrl}/tipogastos`);
  }
  public getTipoGastoById(tipoGastoId: number): Observable<TipoGastos> {
    return this.httpClient.get<TipoGastos>(`${environment.apiUrl}/tipogastos/${tipoGastoId}`);
  }
}
