import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  public showLoader:boolean = false;
 
  constructor() { }

  getErrorMsg(formControl:any, errors:any){
    let errMsg = null;
    if(!formControl.valid && formControl.dirty){
      const keys = Object.keys(errors);
      for(const key of keys){
        if(formControl.errors[key]){
          return errors[key]
        }
      }
    }
    return null;
  }
}
