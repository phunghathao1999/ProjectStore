import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from 'src/app/Admin/product/product.component';
import { DashboardComponent } from 'src/app/Admin/dashboard/dashboard.component';
import { CatelogComponent } from 'src/app/Admin/catelog/catelog.component';
// import { AdminRoutingModule } from './admin-layout-routing.module';

@NgModule({
  declarations: [
    ProductComponent, 
    DashboardComponent, 
    CatelogComponent, 
  ],
  imports: [
    CommonModule,
    // AdminRoutingModule
  ],
  exports: [
  ]
})
export class AdminLayoutModule { }
