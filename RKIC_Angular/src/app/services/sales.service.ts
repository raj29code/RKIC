import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class SaleService {
 readonly CustomerUrl="https://customers-dot-trim-tributary-227514.appspot.com/"; 
readonly OrderRootUrl="https://orders-dot-trim-tributary-227514.appspot.com/";
//readonly rootUrl="http://localhost:7777/";
//http://localhost:7777/
  constructor(private http:HttpClient) { }

 

  getCustomerByPhone(phone:String){
    return  this.http.get(this.CustomerUrl+'getCustomerbyPhone/'+phone);
   }
}
