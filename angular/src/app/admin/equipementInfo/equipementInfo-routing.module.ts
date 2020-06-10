import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EquipementInfoComponent } from './equipementInfo.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: EquipementInfoComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EquipementInfoRoutingModule { }
