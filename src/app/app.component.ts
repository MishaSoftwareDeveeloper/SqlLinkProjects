import { Component } from '@angular/core';
import { AppService } from './services/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SqlLinkPages';
  constructor(private app:AppService){
  }
  ngOnInit(){

  }
  get showLoader(){
    return this.app.showLoader
  }
}
