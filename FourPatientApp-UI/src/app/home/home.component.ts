import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../interfaces/user';
import { HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  user:string = 'bob';
  httpOptions = {
    headers: new HttpHeaders({'Access-Control-Allow-Origin': 'http://localhost:4200'})
  };
  constructor(private http: HttpClient) { 
    let resp = this.http.get("https://localhost:44347/api/Patient/2", this.httpOptions);
    resp.subscribe((result: any) => {
      console.log(result)

      this.user = result.firstName;

    }, error => console.error(error))
  }

  ngOnInit(): void {
  }
  searchHospitals(searchString:string){

  }
}
