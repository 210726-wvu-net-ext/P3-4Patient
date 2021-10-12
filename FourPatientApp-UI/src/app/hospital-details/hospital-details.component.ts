import { Component, Input, OnInit } from '@angular/core';
import { HospitalService } from '../hospital.service';
import { Hospital } from '../interfaces/hospital';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from '../review.service';
import { Review } from '../interfaces/review';

@Component({
  selector: 'app-hospital-details',
  templateUrl: './hospital-details.component.html',
  styleUrls: ['./hospital-details.component.css']
})
export class HospitalDetailsComponent implements OnInit {

  @Input() hospital?: Hospital 
  // @Input() review?: Review;
  
  reviews: Review[] | null = null;

  constructor(private hospitalservice: HospitalService,  private route: ActivatedRoute, private reviewservices : ReviewService) { }

  ngOnInit(): void {
    this.GetDetails();
    this.GetReviewDetails();
  }

  GetDetails() {
    const hospitalid = Number(this.route.snapshot.paramMap.get('id'));
    console.log(hospitalid);
    this.hospitalservice.GetHospitalbyId(hospitalid)
    .subscribe(hospital => this.hospital = hospital);

  }

  GetReviewDetails() {
    const hospitalid = Number(this.route.snapshot.paramMap.get('id'));
    console.log(hospitalid);
    this.reviewservices.GetReviewbyHospitalId(hospitalid)
    .subscribe(reviews => this.reviews = reviews);

  }



}
