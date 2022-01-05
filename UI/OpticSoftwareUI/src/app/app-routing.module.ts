import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full',
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('src/app/features/auth/auth.module').then((x) => x.AuthModule),
  },
  {
    path: 'panel',
    loadChildren: () =>
      import('src/app/features/dashboard/dashboard.module').then(
        (x) => x.DashboardModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
