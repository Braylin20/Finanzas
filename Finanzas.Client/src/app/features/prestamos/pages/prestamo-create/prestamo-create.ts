import { Component, inject, signal } from '@angular/core';
import { ButtonSaveComponent } from '../../../../shared/components/button-save/button-save';
import { FormValidationService } from '../../../../shared/services/form-validation.service';
import { NonNullableFormBuilder, Validators, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PrestamosService } from '../../services/prestamos.service';
import { NotificationService } from '../../../../shared/services/notification.service';
import { finalize } from 'rxjs';
@Component({
  selector: 'features-prestamo-create',
  templateUrl: './prestamo-create.html',
  imports: [ButtonSaveComponent, ReactiveFormsModule],
})
export class PrestamoCreate {
  private readonly prestamosService = inject(PrestamosService);
  private readonly notificationService: NotificationService = inject(NotificationService);
  private formBuilder = inject(NonNullableFormBuilder);
  public formValidation = FormValidationService;

  public isLoading = signal(false);

  prestamoForm: FormGroup = this.formBuilder.group({
    prestamoId: [0],
    descripcion: ['', Validators.required],
    monto: [0, [Validators.required, Validators.min(1)]],
    fecha: [new Date().toISOString().split('T')[0], Validators.required],
  });

  public addPrestamo() {
    if (!this.prestamoForm.valid) {
      this.prestamoForm.markAllAsTouched();
      return;
    }
    this.isLoading.set(true);

    const prestamo = this.prestamoForm.getRawValue();

    this.prestamosService
      .postPrestamo(prestamo)
      .pipe(finalize(() => this.isLoading.set(false)))
      .subscribe({
        next: () => {
          this.notificationService.success('Prestamo agregado correctamente');
        },
      });
  }
}
