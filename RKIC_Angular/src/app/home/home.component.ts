import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
OrderData:any;
  constructor(private router:Router,private orderservice:OrderService) { }

  ngOnInit() {
    this.orderservice.getOrders().subscribe((data:any)=>{
      debugger;
        this.OrderData=data;
        //tested git
    }
  );
  }
Logout()
{
  localStorage.removeItem('userToken');
  this.router.navigate(['/login']);
}
}
