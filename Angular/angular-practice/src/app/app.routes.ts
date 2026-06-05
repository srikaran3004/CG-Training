import { Routes } from '@angular/router';
import { Redirect } from './redirect/redirect';
import { Homepageload } from './homepageload/homepageload';

export const routes: Routes = [
    {
        path: '',
        // Component: () => import('./redirect/redirect').then(m => m.Redirect)
        component: Homepageload
    },
    {
        path: 'redirect',
        component: Redirect
    }
];
