import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'bricks-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  showSideNav:boolean;
  public currentUrl:string;
  constructor(private router:Router){
    
  };
  
  ngOnInit(){
    this.router.events.subscribe((event:any)=>{
      this.currentUrl = event.url;
      console.log(this.currentUrl);
    });

}
}
