import { Component, inject, signal } from '@angular/core';
import { ButtonSaveComponent } from '../../../../shared/components/button-save/button-save';
import { FormValidationService } from '../../../../shared/services/form-validation.service';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { PrestamosService } from '../../services/prestamos.service';
import { NotificationService } from '../../../../shared/services/notification.service';

@Component({
  selector: 'features-prestamo-create',
  templateUrl: './prestamo-create.html',
  imports: [ButtonSaveComponent],
})
export class PrestamoCreate {
  private readonly prestamosService = inject(PrestamosService);
  private readonly notificationService: NotificationService = inject(NotificationService);
  private formBuilder = inject(NonNullableFormBuilder);
  public formValidation = FormValidationService;

  prestamoForm = this.formBuilder.group({
    prestamoId: [0],
    descripcion: ['', Validators.required],
    monto: [0, [Validators.required, Validators.min(1)]],
    fecha: [new Date().toISOString().split('T')[0], Validators.required],
  });

  public addPrestamo() {
    if (!this.prestamoForm.valid) return;

    const prestamo = this.prestamoForm.getRawValue();
    this.prestamosService.postPrestamo(prestamo).subscribe({
      next: (response) => {
        this.notificationService.success('Prestamo agregado correctamente');
      },
    });
  }
}
