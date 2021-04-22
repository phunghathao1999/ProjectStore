import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { throwError } from "rxjs";
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { People } from "../Models/People";

@Injectable({
    providedIn: 'root'
  })
  
  export class PeopleServer {
  
    url = 'https://localhost:5001/api/People';
    constructor(private http: HttpClient){}
    
    // Get: get employees from service
      getEmployees(): Observable<People[]>{
        return this.http.get<People[]>(this.url + '/', {  })
          .pipe(
            catchError(err => {
              return throwError("Error method getEmployee");
            })
          );
      }
  
  }