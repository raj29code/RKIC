import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; //
import { SaleService } from '../services/sales.service';
import { Order } from '../models/order.model';
import swal from 'sweetalert2'; 
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.css']
})
export class SaleComponent implements OnInit {

  constructor(private salesservice:SaleService,private orderservice:OrderService) { }
  public Phone:string;
  public customerdata:any;
  public phoneflag=true;
  public orderformflag=false;
  public customerorder=new Order();
  public bricktypearray = ['Type A', 'Type B',
            'Type C'];
  ngOnInit() {
    this.customerorder.BrickType=this.bricktypearray[0];
  }
  _keyUp(event: any) {
    const pattern = /[0-9\+\-\ ]/;  
    let inputChar = String.fromCharCode(event.keyCode);

    if (!pattern.test(inputChar)) {
      // invalid character, prevent input
      if(this.Phone.length>0)
      {
        this.Phone= this.Phone.substr(0,event.target.value.length-1);
      }
    }
  }
 public verifyCustomer()
 {

    this.salesservice.getCustomerByPhone(this.Phone).subscribe((result:any)=>{
      if(result.Phone)
      {
        this.customerdata=result;
        this.phoneflag=false;
        this.orderformflag=true;
      }
    else
    {
      swal.fire({
        title: 'Wrong Customer Number !',
        text: 'Click Ok to add new customer Or click cancel to enter correct customer Number !',
        type: 'error',
        confirmButtonText: 'Ok',
      })
    }
    })
 }
 totalpriceCal()
 {
   if(this.customerorder.BricksQTY &&this.customerorder.PricePerBrick)
   {
    this.customerorder.TotalAmount=this.customerorder.BricksQTY * this.customerorder.PricePerBrick;
   }
 }
 PendingCal()
 {
  if(this.customerorder.TotalAmount &&this.customerorder.PaidAmount)
  {
   this.customerorder.PendingAmount=this.customerorder.TotalAmount - this.customerorder.PaidAmount;
  }
 }
 onSubmit()
 {
  this.customerorder.CustomerId=this.customerdata._id;
  this.customerorder.DateOfOrder=new Date();
  this.customerorder.LastUpdatedDate=new Date();
  this.customerorder.IsPaymentSettled=this.customerorder.PendingAmount==0?true:false;
  this.customerorder.PaymentDueDate=new Date();


  this.orderservice.addOrder(this.customerorder).subscribe((result)=>{
    swal.fire({
      title: 'Order !',
      text: result.toString(),
      type: 'success',
      confirmButtonText: 'Ok',
    })
  })

 }

}
