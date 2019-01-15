import { environment, classroomsApi } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClassroomModel } from '../models/classroom-model';
import { ExamModel } from './../models/exam-model';

@Injectable({
  providedIn: 'root'
})
export class ClassroomService {
  classroomsApi = '/classrooms';
  host = environment.hostApi;

  constructor(private _http: HttpClient) { }

  getClassrooms(): Observable<Array<ClassroomModel>> {
    return this._http.get(this.host + classroomsApi) as Observable<Array<ClassroomModel>>;
  }
}
