import { IsProfessorGuard } from './core/guards/is-professor.guard';
import { HomeComponent } from './modules/home/page/home.component';
import { LoginComponent } from './modules/account/pages/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateExamComponent } from './modules/professor/components/create-exam/create-exam.component';
import { RegisterComponent } from './modules/account/pages/register/register.component';
import { IsAuthenticatedGuard } from './core/guards/is-authenticated.guard';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { NotAuthorisedComponent } from './core/not-authorised/not-authorised.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'register', component: RegisterComponent },
  { path: 'home', component: HomeComponent, canActivate: [IsAuthenticatedGuard]},
  { path: 'professor/create-exam', component: CreateExamComponent, canActivate: [IsAuthenticatedGuard, IsProfessorGuard] },
  { path: 'not-authorised', component: NotAuthorisedComponent, pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
