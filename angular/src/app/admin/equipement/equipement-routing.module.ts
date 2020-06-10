import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EquipementComponent } from './equipement.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: EquipementComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EquipementRoutingModule { }
