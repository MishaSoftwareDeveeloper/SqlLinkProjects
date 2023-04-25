import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InfoComponent } from './info/info.component';
import { AuthGuard } from './jwt-helper/auth.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'info', component:InfoComponent, canActivate:[AuthGuard]},
  {path:'', redirectTo:'login',pathMatch:'full'},
  {path:'**', redirectTo:'login'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
