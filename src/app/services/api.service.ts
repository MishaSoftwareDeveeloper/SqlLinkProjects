import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': sessionStorage.getItem("token") ? `Bearer ${sessionStorage.getItem("token")}`:''
    })
};

  constructor(private http:HttpClient, private auth:AuthService) { }
  login(authData:any){
    return this.http.post('api/login',authData,this.httpOptions).pipe(
      catchError((error:any)=>{
        if (error.status == 404) {
          sessionStorage.clear();
      }
          
      return throwError(()=> new Error(error));
      })
    )
  }
  getProjects(userId:number){
    return this.http.get(`api/project?userId=${userId}`,this.httpOptions).pipe(
      catchError((error:any)=>{
        if(error.status == 401){//Unauthorized
          this.auth.doLogout();
        } 
        if (error.status == 404) {
          sessionStorage.clear();
      }
      return throwError(()=> new Error(error));
      })
    )
  }
}
