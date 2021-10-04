import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './interfaces/user';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root',
  })
export class UserService{
    user:User;

    constructor(){

    }
    
}
