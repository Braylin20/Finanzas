import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { GastosApiService } from '../../services/gastos-api.service';
import { Gasto } from '../../../../interfaces/Gasto';
import { Router, RouterLink } from '@angular/router';
import { EditIconComponent } from '../../../../shared/components/icons/edit-icon/edit-icon';
import { DeleteIconComponent } from '../../../../shared/components/icons/delete-icon/delete-icon';
import { NotificationService } from '../../../../shared/services/notification.service';
import { DashboardCard } from '../../../../shared/components/dashboard-card/dashboard-card';
import { GastosBusinessService } from '../../services/gastos-business.service';

@Component({
  selector: 'app-gastos-list',
  imports: [
    CurrencyPipe,
    DatePipe,
    RouterLink,
    EditIconComponent,
    DeleteIconComponent,
    DashboardCard,
  ],
  templateUrl: './gastos-list.html',
})
export class GastosList implements OnInit {
  private readonly gastosApiService: GastosApiService = inject(GastosApiService);
  private readonly gastosBusinessService: GastosBusinessService = inject(GastosBusinessService);
  private readonly notificationService = inject(NotificationService);
  private router = inject(Router);
  gastos = signal<Gasto[]>([]);

  public cantidadTotalGastos = computed(() =>
    this.gastosBusinessService.calcularCantidadTotalGastos(this.gastos()),
  );
  public totalMontoGastado = computed(() =>
    this.gastosBusinessService.calcularMontoTotalGastado(this.gastos()),
  );
  public totalGastosMes = computed(() =>
    this.gastosBusinessService.calcularTotalGastosMes(this.gastos()),
  );
  public totalGastosHoy = computed(() =>
    this.gastosBusinessService.calcularTotalGastosHoy(this.gastos()),
  );

  ngOnInit(): void {
    this.getGastos();
  }

  public getGastos() {
    return this.gastosApiService.getGastos().subscribe({
      next: (data) => {
        this.gastos.set(data);
      },
    });
  }

  public async deleteGasto(gastoId: number) {
    const confirmed = await this.notificationService.confirm(
      'Eliminar gasto',
      '¿Seguro que quieres eliminar el gasto?',
    );

    if (confirmed) {
      this.gastosApiService.deleteGasto(gastoId).subscribe({
        next: () => {
          this.notificationService.success('Gasto eliminado exitosamente');
        },
        complete: () => {
          this.getGastos();
          void this.router.navigate(['/gastos']);
        },
      });
    }
  }
}
