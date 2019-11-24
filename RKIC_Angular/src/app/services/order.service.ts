import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class OrderService {
readonly rootUrl="https://orders-dot-trim-tributary-227514.appspot.com/";
//readonly rootUrl="http://localhost:7777/";
//http://localhost:7777/
  constructor(private http:HttpClient) { }

  addOrder(data:any)
  {
      let body=data;
    var reqheader=new HttpHeaders({});
    return this.http.post(this.rootUrl+'addOrder',body,{headers:reqheader});
  }

  getOrders(){
    return  this.http.get(this.rootUrl+'getorders');
   }
}
