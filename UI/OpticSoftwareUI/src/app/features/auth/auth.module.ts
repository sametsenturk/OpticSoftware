import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from 'src/app/core/services/user/user.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {
        path: 'login',
        component: LoginComponent,
      },
    ]),
  ],
  declarations: [LoginComponent],
  exports: [LoginComponent],
  providers: [UserService],
})
export class AuthModule {}
