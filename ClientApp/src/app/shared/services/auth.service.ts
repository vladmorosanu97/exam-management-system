import { UserAuthenticated } from './../models/user-authenticated-model';
import { Injectable } from '@angular/core';
import * as JwtDecode from 'jwt-decode';
import { isNullOrUndefined } from 'util';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _user: UserAuthenticated;
  constructor() {}

  decodeToken(token: string) {
    this._user = JwtDecode(token);
    this._user.Token = token;
    localStorage.setItem('user', JSON.stringify(this._user));
  }

  isAuthenticated() {
    this._user = JSON.parse(localStorage.getItem('user'));
    if (!isNullOrUndefined(this._user)) {
      return true;
    } else {
      return false;
    }
  }

  isProfessor() {
    this._user = JSON.parse(localStorage.getItem('user'));
    if (this._user.Role === 'Professor') {
      return true;
    } else {
      return false;
    }
  }

  isStudent() {
    this._user = JSON.parse(localStorage.getItem('user'));
    if (this._user.Role === 'Student') {
      return true;
    } else {
      return false;
    }
  }

  getUserInfo() {
    this._user = JSON.parse(localStorage.getItem('user'));
    return this._user;
  }

  logout() {
    localStorage.removeItem('user');
    this._user = {
      FirstName: '',
      LastName: '',
      Role: '',
      Token: ''
    };
  }

  getToken() {
    this._user = JSON.parse(localStorage.getItem('user'));
    return this._user ? this._user.Token : null;
  }
}
