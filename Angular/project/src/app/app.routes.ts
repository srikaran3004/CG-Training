import { Routes } from '@angular/router';
import { Verify } from './verify/verify';

export const routes: Routes = [
    {
        path: 'employee',
        loadComponent: () => import('./employee/employee').then(m => m.Employee)
    },
    {
        path:'verify',
        component:Verify
    }

];
