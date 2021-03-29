import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MeterialLibraryModule } from './Share/Material/meterial-library.module';
import { AdminLayoutComponent } from './Layouts/admin-layout/admin-layout.component';
import { AdminLayoutModule } from './Layouts/admin-layout/admin-layout.module';
import { LoginComponent } from './Admin/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MeterialLibraryModule,
    AdminLayoutModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
