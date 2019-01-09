import { CourseService } from './../../../../shared/services/course.service';
import { Component, OnInit } from '@angular/core';
import { CourseModel } from 'src/app/shared/models/course-model';
import { FormGroup, FormControl, RequiredValidator } from '@angular/forms';
import { UserModel } from 'src/app/shared/models/user-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  courses: Array<CourseModel>;
  dropdownSettings = {};
  registerForm: FormGroup;
  user: UserModel;
  constructor(private _courseService: CourseService) {}

  ngOnInit() {
    this._courseService.getCourses().subscribe(data => {
      this.courses = data;
      console.log(this.courses);

      this.dropdownSettings = {
        singleSelection: false,
        idField: 'id',
        textField: 'title',
        selectAllText: 'Select All',
        unSelectAllText: 'UnSelect All',
        itemsShowLimit: this.courses.length,
        allowSearchFilter: true
      };
    });

    this.registerForm = new FormGroup({
      firstName: new FormControl(['' , RequiredValidator]),
      lastName: new FormControl(['' , RequiredValidator]),
      email: new FormControl(['' , RequiredValidator]),
      password: new FormControl(['' , RequiredValidator]),
      repeatePassword: new FormControl(['' , RequiredValidator])
    });
  }

  onItemSelect(item: CourseModel) {
    console.log(item);
  }

  onSelectAll(items: Array<CourseModel>) {
    console.log(items);
  }

  submit() {
    // this.user = {
    //   firstName: this.registerForm.get('firstName').value,

    // }
  }
}
