import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDatepickerModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatNativeDateModule, MatButtonModule, MatRippleModule, MatCard, MatCardModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CourseService } from './services/course.service';
import { HttpClientModule } from '@angular/common/http';
import { CardComponent } from './components/card/card.component';

@NgModule({
  declarations: [CardComponent],
  imports: [
    CommonModule,
    MatDatepickerModule,
     MatFormFieldModule,
     MatInputModule,
     MatSelectModule,
     MatNativeDateModule,
     FormsModule,
     ReactiveFormsModule,
     MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    BrowserAnimationsModule,
    NgMultiSelectDropDownModule,
    HttpClientModule,
    MatCardModule
  ],
  exports: [
    CommonModule,
    MatDatepickerModule,
     MatFormFieldModule,
     MatInputModule,
     MatSelectModule,
     MatNativeDateModule,
     FormsModule,
     ReactiveFormsModule,
     MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    BrowserAnimationsModule,
    NgMultiSelectDropDownModule,
    HttpClientModule,
    MatCardModule
  ]
})
export class SharedModule { }
