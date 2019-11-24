import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { User, LoginRequest, } from './user.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {
readonly rootUrl = environment.baseUrl;
  constructor(private http:HttpClient) { }

  registerUser(body:User)
  {
    var reqheader=new HttpHeaders({'No-Auth':'True'});
    return this.http.post(`${this.rootUrl}Auth/login`,body,{headers:reqheader});
  }
  userAuthentication(userName: string, password: string) {
    const body = new LoginRequest();
    body.UserName = userName;
    body.Password = password;
    const reqHeader = new HttpHeaders({'Content-Type': 'application/json-patch+json'});

    return this.http.post(`${this.rootUrl}Auth/login`, body, {headers: reqHeader});
  }
  getUserClaims(){
    return  this.http.get(this.rootUrl+'/api/GetUserClaims');
   }
}
