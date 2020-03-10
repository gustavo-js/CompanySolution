import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyComponent } from './company/company.component';
import { SupplierComponent } from './supplier/supplier.component';

const routes: Routes = [
  { path: 'companys', component: CompanyComponent },
  { path: 'suppliers', component: SupplierComponent },
  { path: '', redirectTo: '/companys', pathMatch: 'full' }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
