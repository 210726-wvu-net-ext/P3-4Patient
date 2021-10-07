import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profile = "";
  //profileJson;
  //userId;
  //FirstName;
  //LastName;
  //City;
  //Street;
  //State;
  //Phone;
  //Zip;
  constructor(public auth: AuthService) {



   }

  ngOnInit(): void {
    this.auth.user$.subscribe(
      (profile:any)=>(this.profile = JSON.stringify(profile, null, 2))
    );   
  }

}
