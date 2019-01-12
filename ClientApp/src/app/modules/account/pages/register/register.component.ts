import { CourseService } from './../../../../shared/services/course.service';
import { Component, OnInit } from '@angular/core';
import { CourseModel } from 'src/app/shared/models/course-model';
import { FormGroup, FormControl, RequiredValidator } from '@angular/forms';
import { UserModel } from 'src/app/shared/models/user-model';
import { UserService } from 'src/app/shared/services/user.service';
import { Router } from '@angular/router';

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
  roles: Array<string> = ['Professor', 'Student'];
  selectedCourses: Array<number> = new Array<number>();

  constructor(private _courseService: CourseService,
    private _userService: UserService,
    private _router: Router) {}

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
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      repeatePassword: new FormControl(''),
      role: new FormControl('')
    });
  }

  onItemSelect(item: CourseModel) {
    this.selectedCourses.push(item.id);
  }

  onSelectAll(items: Array<CourseModel>) {
    items.forEach(e => {
      this.selectedCourses.push(e.id);
    });
  }

  submit() {
    if (this.registerForm.valid) {
      this.user = {
        firstName: this.registerForm.get('firstName').value,
        courses: this.selectedCourses,
        email: this.registerForm.get('email').value,
        lastName: this.registerForm.get('lastName').value,
        password: this.registerForm.get('password').value,
        role: this.registerForm.get('role').value
      };
     this._userService.register(this.user).subscribe(data => {
        this._router.navigate(['login']);
     })
    }
  }

  login() {
    this._router.navigate(['login']);
  }
}
