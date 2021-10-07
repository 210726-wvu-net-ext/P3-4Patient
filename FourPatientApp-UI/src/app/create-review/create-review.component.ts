import { Component, OnInit, Input } from '@angular/core';
import {FormBuilder, FormGroup, FormControl, Validators} from '@angular/forms';

import { ReviewService } from '../review.service';

@Component({
  selector: 'app-create-review',
  templateUrl: './create-review.component.html',
  styleUrls: ['./create-review.component.css']
})
export class CreateReviewComponent implements OnInit {


  // hospitals: Hospital[] | null = null;

  // cleanlinessForm : FormGroup;
  reviewForm = new FormGroup({
    // id: new FormControl(0),
    comfort: new FormControl(4.43),
    datePosted: new FormControl(null),
    message: new FormControl('This hospital was not P3rfect 12'),
    hospitalid: new FormControl(2),
    patientid: new FormControl(1)
  });

  // get reviewid(){
  //   return this.reviewForm.get('id') as FormControl;
  // };



  cleanlinessForm = new FormGroup({
    id: new FormControl(''),
    waitingroom: new FormControl(''),
    wardroom: new FormControl(''),
    equipment: new FormControl(''),
    bathroom: new FormControl(''),
    averageci: new FormControl('')
  });
  
  nursingForm = new FormGroup({
    id: new FormControl(14),
    attentiveness: new FormControl(''),
    transparency: new FormControl(''),
    knowledge: new FormControl(''),
    compassion: new FormControl(''),
    waitTimes: new FormControl(''),
    averageN: new FormControl('')
  });
  
  covidForm = new FormGroup({
    id: new FormControl(10),
    waitingRooms: new FormControl(''),
    protocols: new FormControl(''),
    separation: new FormControl(''),
    safety: new FormControl(''),
    covid1: new FormControl(''),
    screening: new FormControl(''),
    treatment: new FormControl(''),
    averageC: new FormControl('')
  });

  accommodationForm = new FormGroup({
    id: new FormControl(11),
    checkIn: new FormControl(''),
    discharge: new FormControl(''),
    equipment: new FormControl(''),
    policy: new FormControl(''),
    privacy: new FormControl(''),
    room: new FormControl(''),
    foodOptions: new FormControl(''),
    foodQuality: new FormControl(''),
    dietOptions: new FormControl(''),
    accessibility: new FormControl(''),
    parking: new FormControl(''),
    averageA: new FormControl('')
  });


  constructor(private reviewservice : ReviewService) { }
  // , private formBuilder: FormBuilder

  ngOnInit():void  {
    this.addReview();

    
  }
   addReview(){
    this.reviewservice.AddReview(this.reviewForm .value).subscribe(
      res => {
        console.log(res);
        this.cleanlinessForm.patchValue({
          id: res
        });
        this.nursingForm.patchValue({
          id: res
        });
        this.covidForm.patchValue({
          id: res
        });
        this.accommodationForm.patchValue({
          id: res
        });
        alert("Review has been created");
      }
    );
  }

  addCleanliness(){
    this.reviewservice.AddCleanliness(this.cleanlinessForm.value).subscribe(
      res => {
        alert("Cleanliness survey has been added");
      }
    );
  }

  addNursing(){
    this.reviewservice.AddNursing(this.nursingForm.value).subscribe(
      res => {
        alert("Nursey survey has been added");
      }
    );
  }
  
addCovid(){
  this.reviewservice.AddCovid(this.covidForm.value).subscribe(
    res => {
      alert("Covid survey has been added");
    }
  );

}
addAccommodation(){
  this.reviewservice.AddAccommodation(this.accommodationForm.value).subscribe(
    res => {
      alert("Accommodation survey has been added");
    }
  );

}

  addTotal(){
    this.addCleanliness();
    this.addNursing();
    this.addCovid();
    this.addAccommodation();
  }
}
