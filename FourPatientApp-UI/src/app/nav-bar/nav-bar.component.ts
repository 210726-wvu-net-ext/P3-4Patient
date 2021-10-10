import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  isExpanded = false;

  constructor(public auth: AuthService) {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}