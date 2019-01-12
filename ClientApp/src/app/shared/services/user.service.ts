import { LoginModel } from './../models/login-model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { UserModel } from '../models/user-model';
import { JwtTokenModel } from '../models/jwt-token-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  api = environment.hostApi;
  registerEndPoint = this.api + '/Accounts/register';
  loginEndPoint = this.api + '/Accounts/login';

  constructor(private _httpClient: HttpClient) {}

  register(user: UserModel) {
    return this._httpClient.post(this.registerEndPoint, user);
  }

  login(login: LoginModel): Observable<JwtTokenModel> {
    return this._httpClient.post(this.loginEndPoint, login) as Observable<JwtTokenModel>;
  }
}
