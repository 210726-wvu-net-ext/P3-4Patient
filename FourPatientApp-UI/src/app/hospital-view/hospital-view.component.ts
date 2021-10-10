import { Component, OnInit } from '@angular/core';
import { HospitalService } from '../hospital.service';
import { Hospital } from '../interfaces/hospital';

@Component({
  selector: 'app-hospital-view',
  templateUrl: './hospital-view.component.html',
  styleUrls: ['./hospital-view.component.css']
})
export class HospitalViewComponent implements OnInit {

  constructor(private hospitalservice: HospitalService) { }


  hospitals: Hospital[] | null = null;

  ngOnInit(): void {
    this.GetHospitals();
  }

  GetHospitals()
  {
    this.hospitalservice.ListHospital().subscribe((hospitals) => {
      this.hospitals = hospitals;
    });
    }
}
