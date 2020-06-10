import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TicketSupportComponent } from './ticketSupport.component';
import { UpdateComponent } from './update/update.component';


const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: TicketSupportComponent },
  { path: 'update/:id', component: UpdateComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketSupportRoutingModule { }
