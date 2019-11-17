import { Component, OnInit } from '@angular/core';

import { NgForm } from '@angular/forms';

import {ToastrService} from 'ngx-toastr';
import { User } from 'src/app/shared/user.model';
import { UserService } from 'src/app/shared/user.service';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
user:User;

emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  constructor(private userservice:UserService,private toastrservice:ToastrService) { }

  ngOnInit() {
    this.resetform()
  }
  resetform(form?:NgForm)
  {
    if(form!=null)
    form.reset();
    this.user ={
      UserName:'',
     Password:'',
     Email:'',
     FirstName:'',
     LastName:''
    }
  }
  OnSubmit(form:NgForm)
  {
    this.userservice.registerUser(form.value)
    .subscribe((data:any)=>{
        if(data.Succeeded==true)
        {
            this.resetform(form);
            debugger;
            this.toastrservice.success("Registration Successfull");
        }
        else
        {
          this.toastrservice.error(data.Errors[0]);
        }
    })
  }

}
