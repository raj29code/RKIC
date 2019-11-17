import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { User } from './user.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {
readonly rootUrl="http://localhost:65113/";
  constructor(private http:HttpClient) { }

  registerUser(body:User)
  {
    var reqheader=new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl+'api/User/Register',body,{headers:reqheader});
  }
  userAuthentication(userName,password)
  {
    var data="username="+userName+"&password="+password+"&grant_type=password";
    var reqHeader=new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded','No-Auth':'True'});
    return this.http.post(this.rootUrl+'/token',data,{headers:reqHeader});
  }
  getUserClaims(){
    return  this.http.get(this.rootUrl+'/api/GetUserClaims');
   }
}
