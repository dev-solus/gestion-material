import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
/*{imports}*/

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  {
    path: '', component: AdminComponent,
    children: [
      { path: '', redirectTo: 'affectation', pathMatch: 'full' },
      // { path: 'dash', loadChildren: () => import('./dash/dash.module').then(m => m.DashModule), data: {animation: 'dash'} },
      { path: 'fonction', loadChildren: () => import('./fonction/fonction.module').then(m => m.FonctionModule), data: { animation: 'fonction' } },
      { path: 'service', loadChildren: () => import('./service/service.module').then(m => m.ServiceModule), data: { animation: 'service' } },
      { path: 'ticketSupport', loadChildren: () => import('./ticketSupport/ticketSupport.module').then(m => m.TicketSupportModule), data: { animation: 'ticketSupport' } },
      { path: 'chat', loadChildren: () => import('./chat/chat.module').then(m => m.ChatModule), data: { animation: 'chat' } },
      { path: 'role', loadChildren: () => import('./role/role.module').then(m => m.RoleModule), data: { animation: 'role' } },
      { path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule), data: { animation: 'user' } },
      { path: 'affectation', loadChildren: () => import('./affectation/affectation.module').then(m => m.AffectationModule), data: { animation: 'affectation' } },
      { path: 'equipement', loadChildren: () => import('./equipement/equipement.module').then(m => m.EquipementModule), data: { animation: 'equipement' } },
      { path: 'equipementInfo', loadChildren: () => import('./equipementInfo/equipementInfo.module').then(m => m.EquipementInfoModule), data: { animation: 'equipementInfo' } },
      { path: 'emplacement', loadChildren: () => import('./emplacement/emplacement.module').then(m => m.EmplacementModule), data: { animation: 'emplacement' } },
      { path: 'fournisseur', loadChildren: () => import('./fournisseur/fournisseur.module').then(m => m.FournisseurModule), data: { animation: 'fournisseur' } },
      { path: 'categorie', loadChildren: () => import('./categorie/categorie.module').then(m => m.CategorieModule), data: { animation: 'categorie' } },
      { path: 'statut', loadChildren: () => import('./statut/statut.module').then(m => m.StatutModule), data: { animation: 'statut' } },
      { path: 'constucteur', loadChildren: () => import('./constucteur/constucteur.module').then(m => m.ConstucteurModule), data: { animation: 'constucteur' } },
      { path: 'departement', loadChildren: () => import('./departement/departement.module').then(m => m.DepartementModule), data: { animation: 'departement' } },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
