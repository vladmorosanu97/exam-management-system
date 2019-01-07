import { HomeModule } from './modules/home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FavoriteButtonComponent } from './shared/components/buttons/favorite-button/favorite-button.component';
import { CollapseButtonComponent } from './shared/components/buttons/collapse-button/collapse-button.component';
import { AuthDirective } from './shared/directives/auth.directive';
import { CapitalizePipe } from './shared/pipes/safe.pipe';
import { CoreModule } from './core/core.module';
import { CreateExamComponent } from './modules/create-exam/create-exam.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

@NgModule({
  declarations: [
    AppComponent,
    FavoriteButtonComponent,
    CollapseButtonComponent,
    AuthDirective,
    CreateExamComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    HomeModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
     MatFormFieldModule,
     MatInputModule,
     MatSelectModule,
     MatNativeDateModule,
     FormsModule,
     ReactiveFormsModule,
     NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [CapitalizePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
