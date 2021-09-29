import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  register(lastName:string, firstName:string, DOB:string, address:string, city:string,zip:number, state:string, email:string, phone:string, password:string, confirmpassword:string){
    
  }
}
