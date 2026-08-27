import { Component, Input } from '@angular/core';

@Component({
  selector: 'shared-button-save',
  imports: [],
  template: `
    <button
      type="submit"
      class="rounded-lg bg-green-700 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-green-800 hover:cursor-pointer disabled:bg-gray-400 disabled:cursor-not-allowed disabled:hover:bg-gray-400 disabled:opacity-70"
      [disabled]="isLoading"
      [attr.aria-busy]="isLoading"
    >
      @if (isLoading) {
        <span class="inline-flex items-center gap-2">
          <span
            class="size-4 animate-spin rounded-full border-2 border-white border-t-transparent"
            aria-hidden="true"
          ></span>
          Guardando...
        </span>
      } @else {
        Guardar
      }
    </button>
  `,
})
export class ButtonSaveComponent {
  @Input() isLoading: boolean = false;
}
