import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeterialLibraryModule } from 'src/app/Share/Material/meterial-library.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { LoginComponent } from 'src/app/admin/login/login.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeComponent } from 'src/app/admin/employee/employee.component';

@NgModule({
  declarations: [
    LoginComponent,
    EmployeeComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    MeterialLibraryModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
  ],
  exports: [
    LoginComponent,
    EmployeeComponent,
  ]
})
export class AdminLayoutModule { }
