import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateExamComponent } from './components/create-exam/create-exam.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [CreateExamComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    CreateExamComponent
  ]
})
export class ProfessorModule { }
