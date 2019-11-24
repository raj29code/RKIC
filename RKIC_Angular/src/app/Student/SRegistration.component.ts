import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; //
import { SaleService } from '../services/sales.service';
import { Order } from '../models/Order.model';
import swal from 'sweetalert2'; 
import { OrderService } from '../services/order.service';
import { Qualification, Student } from '../models/registration.model';
import { DatePipe } from '@angular/common';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-sregistration',
  templateUrl: './SRegistration.component.html',
  styleUrls: ['./SRegistration.component.css']
})
export class SRegistrationComponent implements OnInit {

  constructor(private salesservice:SaleService,private orderservice:OrderService,private registrationService:RegistrationService) {

   }
  public Phone:string;
  public genderList =['Male','Female','Transgender','dont Want to tell'];
  public subjectList = ['Hindi','English','math'];
  public studentTypeList = ['Regular','Private'];
  public srcount:number = 0;
  public customerdata:any;
  public phoneflag=true;
  public orderformflag=false;
  public customerorder=new Order();
  public qualificationList:  Qualification[];
  public student = new Student();
  public bricktypearray = ['Type A', 'Type B',
            'Type C'];
  ngOnInit() {
    this.customerorder.BrickType=this.bricktypearray[0];
    this.qualificationList =[];
    this.qualificationList.push(this.getNewQualification());
    this.student.qualification = this.qualificationList;
  }
  _keyUp(event: any) {
    const pattern = /[0-9\+\-\ ]/;  
    let inputChar = String.fromCharCode(event.keyCode);

    if (!pattern.test(inputChar)) {
      // invalid character, prevent input
      if(this.student.mobileNumber.length>0)
      {
        this.student.mobileNumber= this.student.mobileNumber.substr(0,event.target.value.length-1);
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

 console.log(this.student);

  this.registrationService.registerStudent(this.student).subscribe((result)=>{
    swal.fire({
      title: 'Student register successfully !',
      text: result.toString(),
      type: 'success',
      confirmButtonText: 'Ok',
    })
  })
  this.srcount = 0;
  this.initializeStudent();
 }

 public getNewQualification()
 {
  this.srcount ++;
   return {
    serial_number: this.srcount,
    examination:"",
    yearOfPassing:"",
    examinationType:"",
    percentage:"",
    selectedSubject:"",
    instituteName:"",
    board:""};
 }
public AddRow()
{
  this.qualificationList.push(this.getNewQualification());
}
public deleteRow()
{
  this.qualificationList.pop();
  this.srcount --;
}
public initializeStudent()
{
  this.student = new Student();
  this.qualificationList =[];
  this.qualificationList.push(this.getNewQualification());
  this.student.qualification = this.qualificationList;
}

}
