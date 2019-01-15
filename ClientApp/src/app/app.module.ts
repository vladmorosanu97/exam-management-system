import { CardComponent } from './shared/components/card/card.component';
import { AuthInterceptor } from './core/auth-interceptor';
import { IsAuthenticatedGuard } from './core/guards/is-authenticated.guard';
import { AuthService } from './shared/services/auth.service';
import { AccountModule } from './modules/account/account.module';
import { HomeModule } from './modules/home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FavoriteButtonComponent } from './shared/components/buttons/favorite-button/favorite-button.component';
import { CollapseButtonComponent } from './shared/components/buttons/collapse-button/collapse-button.component';
import { AuthDirective } from './shared/directives/auth.directive';
import { CapitalizePipe } from './shared/pipes/safe.pipe';
import { CoreModule } from './core/core.module';
import { ProfessorModule } from './modules/professor/professor.module';
import { SharedModule } from './shared/shared.module';
import { CourseService } from './shared/services/course.service';
import { UserService } from './shared/services/user.service';
import { IsProfessorGuard } from './core/guards/is-professor.guard';
import { IsStudentGuard } from './core/guards/is-student.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    FavoriteButtonComponent,
    CollapseButtonComponent,
    AuthDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    HomeModule,
    SharedModule,
    AccountModule,
    ProfessorModule
  ],
  // tslint:disable-next-line:max-line-length
  providers: [CapitalizePipe, CourseService, UserService, AuthService, IsAuthenticatedGuard, IsProfessorGuard, IsStudentGuard, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],

})
export class AppModule { }
