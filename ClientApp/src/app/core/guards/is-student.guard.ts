import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/shared/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class IsStudentGuard implements CanActivate {
  constructor(private _authService: AuthService, private _router: Router) {}
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const result = this._authService.isStudent();
    if (result) {
      return true;
    } else {
      this._router.navigate(['not-authorised']);
    }
  }
}
