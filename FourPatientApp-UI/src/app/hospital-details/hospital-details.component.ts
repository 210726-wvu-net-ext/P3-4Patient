import { Component, Input, OnInit } from '@angular/core';
import { HospitalService } from '../hospital.service';
import { Hospital } from '../interfaces/hospital';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hospital-details',
  templateUrl: './hospital-details.component.html',
  styleUrls: ['./hospital-details.component.css']
})
export class HospitalDetailsComponent implements OnInit {

  @Input() hospital?: Hospital;

  // hospital: Hospital[] | null = null;

  constructor(private hospitalservice: HospitalService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.GetDetails();
  }

  GetDetails() {
    const hospitalid = Number(this.route.snapshot.paramMap.get('id'));
    console.log(hospitalid);
    this.hospitalservice.GetHospitalbyId(hospitalid)
    .subscribe(hospital => this.hospital = hospital);

  }



}
