import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { EmployeesComponent } from './employees/employees.component';
import { OrdersComponent } from './orders/orders.component';
import {OrdersComponentDe3} from './ordersDe3/ordersDe3.component';
import {DeSo4Component} from './de-so-4/de-so-4.component';
import {DeSo5Component} from './de-so-5/de-so-5.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EmployeesComponent,
    OrdersComponent,
    OrdersComponentDe3,
    DeSo4Component,
    DeSo5Component
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'Employees', component: EmployeesComponent },
      { path: 'orders', component: OrdersComponent },
      { path: 'ordersDe3', component: OrdersComponentDe3 },
      { path: 'deso4', component: DeSo4Component },
      { path: 'deso5', component: DeSo5Component },




    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
