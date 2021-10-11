import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './interfaces/user';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Review } from './interfaces/review';
@Injectable({
    providedIn: 'root',
  })
export class UserService{
    readonly APIUrl="https://localhost:44347/api";
    constructor(private https:HttpClient){ }

    GetReviewbyPatientId(patientid : number) :Observable<Review[]>{
      debugger;
      return this.https.get<Review[]>(this.APIUrl+'/Review/patient/'+ patientid)
    }
}
