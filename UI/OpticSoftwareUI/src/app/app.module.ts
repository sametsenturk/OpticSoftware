import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './features/auth/auth.module';
import { LoginComponent } from './features/auth/login/login.component';
import { DashboardModule } from './features/dashboard/dashboard.module';
import { MenuComponent } from './features/layout/menu/menu.component';
import { ProfileTabComponent } from './features/layout/profile-tab/profile-tab.component';
import { UserComponent } from './features/user/user.component';

@NgModule({
  declarations: [AppComponent, MenuComponent, ProfileTabComponent, UserComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    HttpClientModule,
    DashboardModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
