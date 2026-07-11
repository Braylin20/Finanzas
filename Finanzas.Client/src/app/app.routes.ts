import { Routes } from '@angular/router';
import { GastosList } from './features/gastos/pages/gastos-list/gastos-list';
import { GastoCreate } from './features/gastos/pages/gasto-create/gasto-create';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'gastos',
  },
  {
    path: 'gastos',
    loadChildren: () => import('./features/gastos/gastos.routes').then((m) => m.gastosRoutes),
  },
  {
    path: 'prestamos',
    loadChildren: () => import('./features/prestamos/prestamo.routes').then((m) => m.prestamosRoutes),
  },
];
