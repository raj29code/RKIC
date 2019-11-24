import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Student } from '../models/registration.model';


@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
readonly rootUrl = environment.baseUrl;
  constructor(private http:HttpClient) { }

  registerStudent(body:Student)
  {

    return this.http.post(`${this.rootUrl}Registartion/StudentRegistration`,body);
  }

}
