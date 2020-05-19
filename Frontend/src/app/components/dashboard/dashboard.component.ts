import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User} from "../../models/User"

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }
  user: User = {
    firstName: '',
    lastName: '',
    documentType: '',
    documentNumber: '',
    phone: '',
    email: '',
    password: '',
  };
  ngOnInit(): void {
    this.getUserList()
  }
  //https://localhost:5001/api/Users
  private getUserList() {
    const url = "https://localhost:5001/api/Users";
    this.httpClient
      .get(url)
      .subscribe({
        next: function(data){},
        error: function(err){},
        complete: function(){
          apiData => (this.user = apiData)
          console.log("consumido")
        }
        })
      //.subscribe(apiData => (this.usuarios = apiData));
  }
}
