import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatelogComponent } from './Admin/catelog/catelog.component';
import { DashboardComponent } from './Admin/dashboard/dashboard.component';
import { LoginComponent } from './admin/login/login.component';
import { ProductComponent } from './Admin/product/product.component';
import { AdminLayoutComponent } from './Layouts/admin-layout/admin-layout.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'catelog', component: CatelogComponent },
      { path: 'product', component: ProductComponent },
      { path: '', redirectTo:'dashboard', pathMatch:'full'},
    ]
  },
  {
    path: '',
    component: AdminLayoutComponent,
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
