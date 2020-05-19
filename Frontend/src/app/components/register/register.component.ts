import { Component, OnInit } from '@angular/core';
import {User} from "../../models/User"
import { ContactsService } from '../../service/contacts.service'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  user1: User = {
    firstName: '',
    lastName: '',
    documentType: '',
    documentNumber: '',
    phone: '',
    email: '',
    password: '',
  };
  constructor(private contactsService: ContactsService) { }

  ngOnInit(): void {
  }

  
  user3(): void {
    //this.login1.Username = this.user.email
    //this.login1.Pass = this.user.password 
    console.log(this.user1)
    this.contactsService.register(this.user1)
      .subscribe(
        res => {
          console.log(res);
        },
        err => console.log("Error:"+ err.message)
      );

  }

}
