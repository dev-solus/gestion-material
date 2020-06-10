import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AffectationComponent } from './affectation.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: AffectationComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AffectationRoutingModule { }
