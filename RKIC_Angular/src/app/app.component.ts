import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  public currentUrl="";
  valueDate : Date;
  constructor(private router:Router){
    this.valueDate = new Date();
  };
  ngOnInit(){
    this.router.events.subscribe((event:any)=>{
      this.currentUrl = event.url;
      console.log(this.currentUrl);
    });
  }

}
