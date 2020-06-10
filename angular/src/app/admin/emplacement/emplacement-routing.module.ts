import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmplacementComponent } from './emplacement.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: EmplacementComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmplacementRoutingModule { }
