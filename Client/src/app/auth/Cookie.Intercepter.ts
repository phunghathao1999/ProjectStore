import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CookieInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = request.clone({
      withCredentials:true
    });
      request = this.addHeaders(request);
    return next.handle(request);
  }

  private addHeaders(request: HttpRequest<any>) {
    return request.clone({
      setHeaders: {
        'Content-Type':  'application/json',
      }
    });
  }
}