import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from 'src/app/Admin/product/product.component';
import { DashboardComponent } from 'src/app/Admin/dashboard/dashboard.component';
import { CatelogComponent } from 'src/app/Admin/catelog/catelog.component';
import { MeterialLibraryModule } from 'src/app/Share/Material/meterial-library.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { LoginComponent } from 'src/app/admin/login/login.component';

@NgModule({
  declarations: [
    ProductComponent, 
    DashboardComponent, 
    CatelogComponent, 
    LoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    MeterialLibraryModule
  ],
  exports: [
  ]
})
export class AdminLayoutModule { }
