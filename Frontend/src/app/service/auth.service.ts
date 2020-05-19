import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  api = 'http://localhost:5000/api';
  token;
  constructor() { }
}
