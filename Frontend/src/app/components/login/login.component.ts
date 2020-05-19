import { Component, OnInit } from '@angular/core';
import {User} from "../../models/User"
import {Login} from "../../models/Login"
import { NgForm } from '@angular/forms'
import { ContactsService } from '../../service/contacts.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  token;
 
  login1: Login = {
    Username:"",
    Pass:""
  }
  constructor(private contactsService: ContactsService, private router:Router) { }
 
  ngOnInit(): void {  

  }

  login3(): void {
    //this.login1.Username = this.user.email
    //this.login1.Pass = this.user.password 
    this.contactsService.login(this.login1)
      .subscribe(
        res => {
          console.log(res);
          
          localStorage.setItem('auth_token', res["token"]);
          this.router.navigate(['dashboard']);
          //console.log(res["token"]);
        },
        err => console.log("Error:"+ err)
      );

  }

}
