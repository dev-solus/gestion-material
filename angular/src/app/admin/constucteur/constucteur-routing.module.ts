import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConstucteurComponent } from './constucteur.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: ConstucteurComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConstucteurRoutingModule { }
