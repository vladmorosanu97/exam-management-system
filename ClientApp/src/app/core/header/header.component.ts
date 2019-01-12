import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isAuthenticated: boolean;
  constructor(private _authService: AuthService,
    private _router: Router) {}

  ngOnInit() {
    this.isAuthenticated = this._authService.isAuthenticated();
  }

  logout() {
    this._authService.logout();
    this._router.navigate(['login']);
  }
}
