import { AuthService } from './../../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { UserAuthenticated } from 'src/app/shared/models/user-authenticated-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  user: any;
  constructor(private _authService: AuthService) { }

  ngOnInit() {
    this.user = this._authService.getUserInfo();
  }

}
