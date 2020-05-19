import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { Login } from '../models/Login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  API_URI = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  login(login: Login) {
    return this.http.post(`${this.API_URI}/Login`, login);
  }
  register(user: User) {
    return this.http.post(`${this.API_URI}/Users`, user);
  }
}
