import { Component, inject, signal } from '@angular/core';
import { ButtonSaveComponent } from '../../../../shared/components/button-save/button-save';
import { FormValidationService } from '../../../../shared/services/form-validation.service';
import { NonNullableFormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'features-prestamo-create',
  templateUrl: './prestamo-create.html',
  imports: [ButtonSaveComponent],
})
export class PrestamoCreate {
  private formBuilder = inject(NonNullableFormBuilder);
  public formValidation = FormValidationService;

  prestamoForm = this.formBuilder.group({
    prestamoId: [0, Validators.required],
    descripcion: ['', Validators.required],
    monto: [0, [Validators.required, Validators.min(1)]],
    fecha: [new Date().toISOString().split('T')[0], Validators.required],
  });
}
