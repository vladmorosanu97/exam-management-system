import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/shared/services/course.service';
import { ClassroomService } from './../../../../shared/services/classroom.service';
import { ClassroomModel } from './../../../../shared/models/classroom-model';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, Validators , FormsModule , NgForm, Form, FormControl } from '@angular/forms';
import { ExamModel } from './../../../../shared/models/exam-model';
import { ExamService } from 'src/app/shared/services/exam.service';

@Component({
  selector: 'app-create-exam',
  templateUrl: './create-exam.component.html',
  styleUrls: ['./create-exam.component.scss']
})
export class CreateExamComponent implements OnInit {
  // dropdownList = [];
  dropdownSettings = {};
  classroomsList = [];
  examForm: FormGroup;
  examModel: ExamModel;

  constructor(
    private _courseServices: CourseService,
    private _classroomServices: ClassroomService,
    private _examService: ExamService) { }

  ngOnInit() {

    this.examForm = new FormGroup({
      title: new FormControl(''),
      description: new FormControl(''),
      date: new FormControl(''),
      startHour: new FormControl(''),
      finishHour: new FormControl(''),
      courseId: new FormControl(''),
      professorId: new FormControl(''),
      classroomsList: new FormGroup({
        id: new FormControl(''),
        name: new FormControl('')
      })
    });

    // this.dropdownList = [
    //   { item_id: 1, item_text: 'C2' },
    //   { item_id: 2, item_text: 'C112' },
    //   { item_id: 3, item_text: 'C410' },
    //   { item_id: 4, item_text: 'C413' },
    //   { item_id: 5, item_text: 'C310' }
    // ];

    this.dropdownSettings = {
      singleSelection: false,
      idField: ClassroomModel.prototype.id,
      textField: ClassroomModel.prototype.name,
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: this.classroomsList.length,
      allowSearchFilter: true
    };

    this._classroomServices.getClassrooms().subscribe(data => {
      this.classroomsList  = Object.assign([], data);
    })

    this._courseServices.getCourses().subscribe(data => {
      console.log(data);
    });
  }

  createExam() {

    this.examModel = {
      id: 1,
      title: this.examForm.get('title').value,
      description: this.examForm.get('description').value,
      date: this.examForm.get('date').value,
      startHour: this.examForm.get('startHour').value,
      finishHour: this.examForm.get('finishHour').value,
      courseId: this.examForm.get('course').value,
      professorId: 1,
      classroomsList: this.examForm.get('classrooms').value
    };

    this._examService.createExam(1, this.examModel).subscribe();

    // let examObj = form.getRawValue();
    // let serializedForm = JSON.stringify(examObj);
  }

  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
}
