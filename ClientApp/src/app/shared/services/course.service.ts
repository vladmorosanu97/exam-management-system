import { environment, coursesApi } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseModel } from '../models/course-model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  coursesApi = '/Courses';
  host = environment.hostApi;

  constructor(private _http: HttpClient) { }

  getCourses(): Observable<Array<CourseModel>> {
    return this._http.get(this.host + coursesApi) as Observable<Array<CourseModel>>;
  }
}
