import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TotalComponent } from './total/total.component';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

@NgModule({
  declarations: [DashboardComponent, TotalComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: DashboardComponent,
      },
    ]),
  ],
  exports: [DashboardComponent, TotalComponent],
})
export class DashboardModule {}
