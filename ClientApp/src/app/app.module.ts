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


@NgModule({
  declarations: [
    AppComponent,
    FavoriteButtonComponent,
    CollapseButtonComponent,
    AuthDirective,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    HomeModule
  ],
  providers: [CapitalizePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
