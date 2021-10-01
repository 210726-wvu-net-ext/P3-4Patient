import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hospital } from './interfaces/hospital';


@Injectable({
    providedIn: 'root'
  })

  export class HospitalService {
    readonly APIUrl="https://localhost:44347/api";
  
    constructor(private https:HttpClient) { }

    ListHospital():Observable<Hospital[]>{
      return this.https.get<Hospital[]>(this.APIUrl+'/Hospital');
    }


  }