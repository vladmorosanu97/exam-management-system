import { AuthService } from 'src/app/shared/services/auth.service';
import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private _authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this._authService.getToken();
    if (token) {
      // Logged in. Add Bearer token.
      return next.handle(
        req.clone({
          headers: req.headers.append('Authorization', 'Bearer ' + token)
        })
      );
    }
    // Not logged in. Continue without modification.
    return next.handle(req);
  }
}
