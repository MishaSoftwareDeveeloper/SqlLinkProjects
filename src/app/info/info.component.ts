import { Component, ViewChild } from '@angular/core';
import { MatSort, Sort } from '@angular/material/sort';
import { Subscription } from 'rxjs';
import { ApiService } from '../services/api.service';
import { AppService } from '../services/app.service';
import { AuthService } from '../services/auth.service';
import {MatTableDataSource} from '@angular/material/table'


@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent {
  public personalDetails:any = null;
  public projects:Array<any> = [];
  public dataSource:any;
  public displayedColumns:Array<string>=[];
  private projectSubscription:Subscription;
  constructor(private api:ApiService, private auth:AuthService, 
    private appServ:AppService){
  }
  @ViewChild(MatSort) sort: MatSort;
  ngOnInit(){
    this.personalDetails = this.auth.personalDetails
    this.appServ.showLoader = true;
    debugger
    if(this.personalDetails){
      this.projectSubscription = this.api.getProjects(this.personalDetails.Id).subscribe((data:any)=>{
        if(data && data.length > 0){
          this.projects = data;
          let columns = Object.keys(this.projects[0]);
          for(let c of columns){
            if( c!="id" && c!="userId"){
              this.displayedColumns.push(c);
            }
          }
          this.dataSource = new MatTableDataSource(this.projects);
        }
        this.appServ.showLoader = false;
      },
      (error:any)=>{
        this.appServ.showLoader = false;
        console.log(error)}
      )
    }
  }
  ngAfterViewInit() {
    setTimeout(()=>{
      this.dataSource.sort = this.sort;
    },800)

  }

  getMadeDateLine(elem:boolean){
    if(elem){
      return "Yes";
    }
    return "No";
  }

  applyFilter(event: Event): void {
    let filter = (event.target as HTMLInputElement).value.trim().toLocaleLowerCase();
    if("yes".indexOf(filter) != -1){
      filter = "true";
    }
    if("no".indexOf(filter) != -1){
      filter = "false";
    }
    this.dataSource.filter = filter;
  }

  scoreLess(score:number){
    return score < 70;
  }
  
  scoreMore(score:number){
    return score > 90;
  }

  getAverageScore(){
    const sum = this.dataSource?.filteredData.reduce((a:number, b:any) =>{ return a + b.score}, 0);
    return (sum / this.dataSource?.filteredData.length).toFixed(2) || 0;
  }

  getPersentage(){
    const success = this.dataSource?.filteredData.filter((d:any) =>{ return d.madeDadeline == true}).length;
    return ((success / this.dataSource?.filteredData.length)*100).toFixed(2) || 0;
  }

  ngOnDestroy(){
    this.projectSubscription.unsubscribe();
  }
}
