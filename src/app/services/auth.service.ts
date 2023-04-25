import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _personalDetails:any;

  constructor(private router:Router ) { }

  get personalDetails(){
    let details = JSON.parse(sessionStorage.getItem('details'));
    if(!details)
      return this._personalDetails;
    return details;
  }

  set personalDetails(details:any){
      sessionStorage.setItem('details', JSON.stringify(details));
      this._personalDetails = details;
  }

  doLogout(){
    sessionStorage.clear();
    this.router.navigate(['./login']);
  }

}
