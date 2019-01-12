import { AuthService } from './../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-authorised',
  templateUrl: './not-authorised.component.html',
  styleUrls: ['./not-authorised.component.scss']
})
export class NotAuthorisedComponent implements OnInit {

  constructor(private _router: Router) { }

  ngOnInit() {
  }

  redirectHome() {
    this._router.navigate(['home']);
  }
}
