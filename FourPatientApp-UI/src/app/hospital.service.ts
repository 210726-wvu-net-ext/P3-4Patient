import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';

Injectable({
    providedIn: 'root'
  })
  export class HospitalService {
    readonly APIUrl="https://localhost:44357/api";
  
    constructor(private https:HttpClient) { }

  }