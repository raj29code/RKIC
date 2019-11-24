import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import swal from 'sweetalert2'; 

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class loginComponent implements OnInit {

  isLoginError:boolean=false;
  constructor(private userService:UserService,private router:Router) { }

  ngOnInit() {
  }

  public OnSubmit(userName:string, Password:string){
        this.userService.userAuthentication(userName,Password).subscribe((data : any)=>{
      debugger;
     localStorage.setItem('userToken',data.accessToken.token);
     this.router.navigate(['/home']);
   },
   (err : HttpErrorResponse)=>{
     this.isLoginError = true;
     swal.fire({
      title: 'Wrong UserName Pawword !',
      text: 'Click Ok and Enter Correct credentials',
      type: 'error',
      confirmButtonText: 'Ok',
    })
   });
  }
}
