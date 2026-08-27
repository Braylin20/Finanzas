import { Component, Input } from '@angular/core';

@Component({
  selector: 'shared-button-save',
  imports: [],
  template: `
    <button
      type="submit"
      class="rounded-lg bg-green-700 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-green-800 hover:cursor-pointer disabled:bg-gray-400 disabled:cursor-not-allowed disabled:hover:bg-gray-400 disabled:opacity-70"
      [disabled]="isLoading"
    >
      Guardar
    </button>
  `,
})
export class ButtonSaveComponent {
  @Input() isLoading: boolean = false;
}
