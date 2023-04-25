import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ApiService } from '../services/api.service';
import { AppService } from '../services/app.service';
import { AuthService } from '../services/auth.service';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  public loginForm:FormGroup;
  private loginSubscription: Subscription;
  public isFailed:boolean = false;
  constructor(private router:Router, 
    private loginSrv:LoginService, 
    private appSrv:AppService,
    private api:ApiService,
    private auth:AuthService){
  }
  ngOnInit(){
    this.loginForm = this.loginSrv.generateFormGroup();
  }

  getErrorMsg(formControlName:string){
    return this.appSrv.getErrorMsg(this.loginForm.get(formControlName),this.loginSrv.errorMsgs[formControlName]);
  }

  submit(){
    for(const ctrlName in this.loginForm.controls){
      this.loginForm.controls[ctrlName].markAsDirty();
    }
    if(this.loginForm.valid){
     
      let authData = {
        email:this.loginForm.controls['email'].value,
        password:this.loginForm.controls['password'].value
      }
    
      this.appSrv.showLoader = true;
      this.loginSubscription = this.api.login(authData).subscribe((res:any)=>{
        if(res){
          sessionStorage.setItem('token', res.token);
          this.auth.personalDetails = res.personalDetails;
          this.appSrv.showLoader = false;
          this.router.navigate(['./info'])
        }
      },
      (err:any)=>{
        this.appSrv.showLoader = false;
        this.isFailed = true;
        setTimeout(()=>{
          this.isFailed = false;
        },3000);
        console.log(err);
       
      })
    }
  }
  ngOnDestroy(){
    this.loginSubscription.unsubscribe();
  }
}
