import { Injectable } from "@angular/core";
import { Router, CanActivate } from "@angular/router";
import { AuthService } from "../services/auth.service";



@Injectable({providedIn:'root'})
export class AuthGuard implements CanActivate{
    constructor(private auth:AuthService, private router:Router){

    }
    canActivate():boolean{
        let token =  sessionStorage.getItem('token');
        if(token){
            return true
        }

        //this.router.navigate(['./info']);
        return true;

    }
}