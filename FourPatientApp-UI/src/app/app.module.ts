import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { CreateReviewComponent } from './create-review/create-review.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountComponent } from './account/account.component';
import { HospitalViewComponent } from './hospital-view/hospital-view.component';


import { HospitalService } from './hospital.service';
import { HospitalDetailsComponent } from './hospital-details/hospital-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSliderModule } from '@angular/material/slider';
import {MatStepperModule} from '@angular/material/stepper';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import {MatChipsModule} from '@angular/material/chips';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';




import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './interceptor.service';
import { AuthService } from './auth.service';
import { ReviewViewComponent } from './review-view/review-view.component';


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    CreateReviewComponent,
    LoginComponent,
    RegisterComponent,
    AccountComponent,
    HospitalViewComponent,

    HospitalDetailsComponent,
      ReviewViewComponent,
   

  ],
  imports: [
    HttpClientModule,
    FormsModule,
    RouterModule,
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'create-review', component: CreateReviewComponent },
      { path: 'hospital-view', component: HospitalViewComponent },
      { path: 'account', component: AccountComponent },
      { path: 'register', component: RegisterComponent },
      {path: 'details/:id', component: HospitalDetailsComponent},
     
  
   
    ]),
    BrowserAnimationsModule,
    MatSliderModule,
    MatStepperModule,   
    MatIconModule,
    MatBottomSheetModule, 
    MatButtonModule,
    MatButtonToggleModule,
 

    MatChipsModule,
    MatInputModule,
    MatListModule,

  ],

  providers: [/*{
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorService,
    multi: true
  },*/HospitalService],
  bootstrap: [AppComponent]
})
export class AppModule { }


  