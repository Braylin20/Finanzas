import { GastosList } from './pages/gastos-list/gastos-list';
import { GastoCreate } from './pages/gasto-create/gasto-create';

export const gastosRoutes = [
  {
    path: '',
    component: GastosList,
  },
  {
    path: 'crear',
    component: GastoCreate,
  },
  {
    path: 'editar/:gastoId',
    component: GastoCreate,
  },
];
