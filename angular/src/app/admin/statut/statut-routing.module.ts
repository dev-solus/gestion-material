import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StatutComponent } from './statut.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: StatutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StatutRoutingModule { }
