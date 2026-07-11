import { Component, input } from '@angular/core';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'shared-dashboard-card',
  imports: [CurrencyPipe],
  template: `
    <article
      class="rounded-lg border border-slate-200 bg-white p-4 shadow-sm transition hover:-translate-y-0.5 hover:border-emerald-200 hover:shadow-md"
    >
      <div class="flex items-start gap-3">
        <div
          class="flex h-11 w-11 shrink-0 items-center justify-center rounded-lg bg-emerald-50 text-emerald-700 ring-1 ring-emerald-100"
        >
          <span class="text-lg font-bold">$</span>
        </div>
        <div class="min-w-0 flex-1">
          <div class="space-y-0.5">
            <p class="truncate text-sm font-semibold leading-5 text-slate-900">
              {{ title() }}
            </p>
            <p class="text-xs font-medium leading-4 text-slate-500">
              {{ subtitulo() }}
            </p>
          </div>
          <p class="mt-3 truncate text-2xl font-bold leading-7 text-slate-950">
            {{
              totalCantidadGastos() ??
                (totalMontoGastado() ?? totalGastosHoy() ?? totalGastosMes() | currency)
            }}
          </p>
        </div>
      </div>
    </article>
  `,
  styleUrl: './dashboard-card.css',
})
export class DashboardCard {
  title = input.required<string>();
  subtitulo = input.required<string>();
  totalCantidadGastos = input<number>();
  totalMontoGastado = input<number>();
  totalGastosHoy = input<number>();
  totalGastosMes = input<number>();
}
