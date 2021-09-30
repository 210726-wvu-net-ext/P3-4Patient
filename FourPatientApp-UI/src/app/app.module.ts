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
import { HerosectionComponent } from './herosection/herosection.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './interceptor.service';
import { AuthService } from './auth.service';

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
    HerosectionComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'create-review', component: CreateReviewComponent },
      { path: 'hospital-view', component: HospitalViewComponent },
      { path: 'account', component: AccountComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'hero', component: HerosectionComponent },
   
    ])

  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
