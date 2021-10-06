import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from './interfaces/review';
import { Cleanliness } from './interfaces/cleanliness';


@Injectable({
    providedIn: 'root'
  })

  export class ReviewService {
    readonly APIUrl="https://localhost:44347/api";
  
    constructor(private https:HttpClient) { }

    // ListRe():Observable<Hospital[]>{
     //  return this.https.get<Hospital[]>(this.APIUrl+'/Hospital');
    // }
    ListCleanliness():Observable<Cleanliness[]>{
        return this.https.get<Cleanliness[]>(this.APIUrl+'/Cleanliness');
    }

    AddCleanliness(cleanliness : Cleanliness) : Observable<Cleanliness>{
        return this.https.post<Cleanliness>(this.APIUrl+'/Cleanliness/Create',cleanliness)

    }

    GetReviewbyId(id : number){
      
      return this.https.get<Review>(this.APIUrl+'/Review/'+ id)
    }
  }