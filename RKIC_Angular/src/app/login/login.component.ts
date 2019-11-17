import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';

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
  public OnSubmit(){
    this.router.navigate(['/home']);
  }
}
