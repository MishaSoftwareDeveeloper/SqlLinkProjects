import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Constants } from '../share/Constants';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private fb:FormBuilder) { }

  get errorMsgs(){
    return {
      email:{
        required:'Email Is required',
        pattern:'Email address is not correct'
      },
      password:{
        required:'Password Is required',
        pattern:'Password must include one uppercase character and min length 8'
      }
    }
  }

  generateFormGroup(){
    return this.fb.group({
      email:[null, {validators:[Validators.required,Validators.pattern(Constants.REGEX.EMAIL)],updateOn:'blur'}],
      password:[null,{validators:[Validators.required,
        Validators.pattern(Constants.REGEX.PASSWORD)],updateOn:'blur'}]
    })
  }
}
