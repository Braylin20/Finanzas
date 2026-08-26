import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/enviorenments';
import { Prestamo } from '../../../interfaces/Prestamo';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class PrestamosService {
  private readonly httpCliente: HttpClient = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  public postPrestamo(prestamo: Prestamo): Observable<Prestamo> {
    return this.httpCliente.post<Prestamo>(`${this.apiUrl}/prestamos`, prestamo);
  }
}
