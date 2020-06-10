import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TicketSupportComponent } from './ticketSupport.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: TicketSupportComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketSupportRoutingModule { }
