import { Router } from '@angular/router';
import { JwtTokenModel } from './../../../../shared/models/jwt-token-model';
import { AuthService } from './../../../../shared/services/auth.service';
import { LoginModel } from './../../../../shared/models/login-model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loginModel: LoginModel;
  jwtToken: JwtTokenModel;
  constructor(private _userService: UserService,
    private _authService: AuthService,
    private _router: Router) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl(''),
      password: new FormControl(''),
    });
  }

  submit() {
    if (this.loginForm.valid) {
      this.loginModel = {
        username: this.loginForm.get('username').value,
        password: this.loginForm.get('password').value
      };

      this._userService.login(this.loginModel).subscribe(data => {
        this.jwtToken = data;
        this._authService.decodeToken(this.jwtToken.access_token);
        this._router.navigate(['/home']);
      });
    }
  }

  register() {
    this._router.navigate(['register']);
  }

}
