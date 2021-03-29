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
      { path: '', redirectTo:'dashboard', pathMatch:'full'},
      { path: 'dashboard', component: DashboardComponent },
      { path: 'catelog', component: CatelogComponent },
      { path: 'product', component: ProductComponent },
      { path: 'login', component: LoginComponent },
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
