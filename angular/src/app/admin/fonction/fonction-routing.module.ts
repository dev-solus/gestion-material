import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FonctionComponent } from './fonction.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: FonctionComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FonctionRoutingModule { }
