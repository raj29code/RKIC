import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrls: ['./top-menu.component.css']
})
export class TopMenuComponent implements OnInit {
OrderData:any;
  constructor(private router:Router,) { }

  ngOnInit() {


  }
Logout()
{
  localStorage.removeItem('userToken');
  this.router.navigate(['/login']);
}
}
