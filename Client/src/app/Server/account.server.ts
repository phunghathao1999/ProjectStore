import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { catchError, map, mapTo, tap } from 'rxjs/operators';

import { Account } from '../Models/Account';
import { Common } from '../Share/Common';
import { Login } from '../Models/Login';

@Injectable({
  providedIn: 'root'
})

export class AccountServer {

  url = 'https://localhost:44336/api/People';
  constructor(
    private http: HttpClient,
  ) {}

  login(login: Login): Observable<boolean> {
    return this.http.post<any>(`${this.url}/login`, login)
      .pipe(
        map((data: any) => {
          this.storeTokens(data.data)
          return{
            ...data,
          }
        }),
        catchError(error => {
          return of(false);
        })
      );
  }

  logout() {
    return this.http.post<any>(this.url + '/logout', {})
      .pipe(
        tap(() => {
          this.removeTokens()
        }),
        mapTo(true),
        catchError(error => {
          return of(false);
        }));
  }

  getJwtUser() {
    return sessionStorage.getItem(Common.USER);
  }

  private storeTokens(account: Account) {
    sessionStorage.setItem(Common.USER, account.username);
    sessionStorage.setItem(Common.ROLE, account.roles);
  }

  private removeTokens() {
    sessionStorage.removeItem(Common.USER);
    sessionStorage.removeItem(Common.ROLE);
  }

}