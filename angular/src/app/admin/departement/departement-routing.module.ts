import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepartementComponent } from './departement.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: DepartementComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartementRoutingModule { }
