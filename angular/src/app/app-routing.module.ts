import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { MyGuard } from './shared/my.guard';

const routes: Routes = [
  { path: '', redirectTo: 'auth', pathMatch: 'full'},
  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule), },
  { path: 'desktop', loadChildren: () => import('./desktop/desktop.module').then(m => m.DesktopModule), },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule), canActivate: [MyGuard]},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules
    }),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
