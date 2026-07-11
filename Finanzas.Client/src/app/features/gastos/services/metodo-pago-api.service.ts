import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MetodoPago } from '../../../interfaces/MetodoPago';
import { environment } from '../../../../environments/enviorenments';

@Injectable({
  providedIn: 'root',
})
export class MetodoPagoApiService {
  httpClient = inject(HttpClient)

  getMetodoPagos(): Observable<MetodoPago[]>{
    return this.httpClient.get<MetodoPago[]>(`${environment.apiUrl}/metodoPago`);
  }
}
