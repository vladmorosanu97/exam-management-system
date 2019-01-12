import { AuthService } from './../../shared/services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IsAuthenticatedGuard implements CanActivate {
  /**
   *
   */
  constructor(private _authService: AuthService, private _router: Router) {}
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const result = this._authService.isAuthenticated();
    if (result) {
      return true;
    } else {
      this._router.navigate(['/login']);
    }
  }
}
