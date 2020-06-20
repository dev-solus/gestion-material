import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DesktopComponent } from './desktop.component';


const routes: Routes = [
  { path: '', redirectTo: 'welcome', pathMatch: 'full' },
  {
    path: 'welcome', component: DesktopComponent,
    // children: [
    //   { path: '', redirectTo: 'home', pathMatch: 'full'},
    // ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DesktopRoutingModule { }
