import { environment, coursesApi } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExamModel } from '../models/exam-model';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  host = environment.hostApi;

  constructor(private _http: HttpClient) { }

  createExam(professorId, exam: ExamModel): Observable<ExamModel> {
    return this._http.post(this.host + coursesApi + `/${professorId}` + '/exams', exam) as Observable<ExamModel>;;
  }
}
