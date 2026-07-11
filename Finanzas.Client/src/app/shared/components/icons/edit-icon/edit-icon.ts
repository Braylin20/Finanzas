import { Component } from '@angular/core';

@Component({
  selector: 'shared-edit-icon',
  imports: [],
  template: `
    <svg
      aria-hidden="true"
      class="h-4 w-4"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <path d="M12 20h9" />
      <path d="M16.5 3.5a2.1 2.1 0 0 1 3 3L7 19l-4 1 1-4Z" />
    </svg>
  `,
})
export class EditIconComponent {}
