
import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { SaleComponent } from './sale/sale.component';
import { loginComponent } from './login/login.component';
 
export const appRoutes: Routes = [
   //  need to implement after authentication //{ path: 'home', component: HomeComponent,canActivate:[AuthGuard] },
    { path: 'home', component: HomeComponent },
    { path: 'Sale', component: SaleComponent },
    
    {
        path: 'login', component: loginComponent,
  
    },
    { path : '', redirectTo:'/login', pathMatch : 'full'}
    
];