import { Component, OnInit, Input } from '@angular/core';
import {FormBuilder, FormGroup, FormControl, Validators} from '@angular/forms';

import { ReviewService } from '../review.service';

@Component({
  selector: 'app-create-review',
  templateUrl: './create-review.component.html',
  styleUrls: ['./create-review.component.css']
})
export class CreateReviewComponent implements OnInit {

  // cleanlinessForm : FormGroup;

  cleanlinessForm = new FormGroup({
    waitingroom: new FormControl(null),
    wardroom: new FormControl(null),
    equipment: new FormControl(null),
    bathroom: new FormControl(null),
    averageci: new FormControl(4),
  });
  
  constructor(private reviewservice : ReviewService) { }
  // , private formBuilder: FormBuilder

  ngOnInit():void  {
  
    //  this.cleanlinessForm = this.formBuilder.group({
    //    waitingroom: [''],
    //    wardroom: [''],
    //    equipment: [''],
    //    bathroom: [''],
    //    averageci: [''],
    //    });
    
  }

  onSubmit(){
    this.reviewservice.AddCleanliness(this.cleanlinessForm.value).subscribe(
      res => {
        alert("Cleanliness survey has been added");
      }
    );
  }
}
