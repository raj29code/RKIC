import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatSidenavModule} from '@angular/material';
import { AppComponent } from './app.component';
import { UserService } from './shared/user.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';
//import {MatSidenavModule} from '@angular/material/sidenav';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './route';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.Interceptor';
import { OrderService } from './services/order.service';
import { TopMenuComponent } from './menu/topmenu/top-menu.component';
import { SaleComponent } from './sale/sale.component';
import { loginComponent } from './login/login.component';
import { SaleService } from './services/sales.service';
import { SidenavComponent } from './sidenav/sidenav.component';
import {MatCardModule} from '@angular/material/card';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@ANGULAr/material/icon';
@NgModule({
  declarations: [
    AppComponent,
    loginComponent,
    HomeComponent,
    TopMenuComponent,
    SaleComponent,
    SidenavComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatSidenavModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
   // MatSidenavModule
  ],
  providers: [UserService,AuthGuard
  ,OrderService,SaleService
// {
//   provide:HTTP_INTERCEPTORS,
//   useClass:AuthInterceptor,
//   multi:true
// }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
