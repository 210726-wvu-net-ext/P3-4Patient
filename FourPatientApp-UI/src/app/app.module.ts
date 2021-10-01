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
      { path: 'details', component: HospitalDetailsComponent },
  
   
    ])

  ],
  providers: [HospitalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
