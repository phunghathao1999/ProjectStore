import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './admin/employee/employee.component';
import { LoginComponent } from './admin/login/login.component';
import { AdminLayoutComponent } from './Layouts/admin-layout/admin-layout.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'employee', component: EmployeeComponent },
      { path: '', redirectTo:'employee', pathMatch:'full'},
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
