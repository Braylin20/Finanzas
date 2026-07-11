import { Component, inject, OnInit, signal } from '@angular/core';
import { ButtonSaveComponent } from '../../../../shared/components/button-save/button-save';
import { FormGroup, NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { GastosApiService } from '../../services/gastos-api.service';
import { Gasto } from '../../../../interfaces/Gasto';
import { FormValidationService } from '../../../../shared/services/form-validation.service';
import { NotificationService } from '../../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoGastos } from '../../../../interfaces/TipoGastos';
import { MetodoPago } from '../../../../interfaces/MetodoPago';
@Component({
  selector: 'feature-gasto-create',
  imports: [ButtonSaveComponent, ReactiveFormsModule],
  templateUrl: './gasto-create.html',
})
export class GastoCreate implements OnInit {
  private readonly gastosApiService = inject(GastosApiService);
  private formBuilder = inject(NonNullableFormBuilder);
  private readonly notificationService = inject(NotificationService);
  public formValidation = FormValidationService;
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  public tipoGastos = signal<TipoGastos[]>([]);
  public metodoPagos = signal<MetodoPago[]>([]);

  public gastoId = Number(this.route.snapshot.paramMap.get('gastoId'));

  ngOnInit() {
    if (this.gastoId) {
      this.getGastoById();
    }
    this.getTipoGasto();
    this.getMetodoPagos();
  }

  public gastoForm: FormGroup = this.formBuilder.group({
    gastoId: [0],
    tipoGastoId: [0, Validators.min(1)],
    metodoPagoId: [0, Validators.min(1)],
    descripcion: ['', Validators.required],
    monto: [0, [Validators.required, Validators.min(1)]],
    fecha: [new Date().toISOString().split('T')[0], Validators.required],
  });

  public saveGasto() {
    if (this.gastoForm.invalid) {
      this.gastoForm.markAllAsTouched();
      return;
    }

    const gasto = this.gastoForm.getRawValue();

    if (this.gastoId) {
      this.putGasto(gasto);
      return;
    }

    console.log(gasto);
    this.gastosApiService.postGasto(gasto).subscribe({
      next: () => {
        this.notificationService.success('Gasto guardado');
      },
      complete: () => {
        this.gastoForm.reset();
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.message);
      },
    });
  }

  public getGastoById() {
    return this.gastosApiService.getGastoById(this.gastoId).subscribe({
      next: (gasto: Gasto) => {
        this.gastoForm.patchValue({
          gastoId: gasto.gastoId,
          descripcion: gasto.descripcion,
          monto: gasto.monto,
          fecha: gasto.fecha.split('T')[0],
          tipoGastoId: gasto.tipoGastoId,
          metodoPagoId: gasto.metodoPagoId,
        });
      },
    });
  }

  public putGasto(gasto: Gasto) {
    this.gastosApiService.putGasto(gasto).subscribe({
      next: () => {
        this.notificationService.success('Gasto actualizado');
      },
      complete: () => {
        void this.router.navigate(['/gastos']);
      },
    });
  }

  public getTipoGasto() {
    this.gastosApiService.getTipoGastos().subscribe({
      next: (gastos: TipoGastos[]) => {
        this.tipoGastos.set(gastos);
      },
    });
  }
  public getMetodoPagos() {
    this.gastosApiService.getMetodoPagos().subscribe({
      next: (metodoPagos: MetodoPago[]) => {
        this.metodoPagos.set(metodoPagos);
      },
    });
  }
}
