import { Time } from "@angular/common";

export interface Review {
    id: number,
    comfort: number,
    datePosted: Date, 
    message: string,
    hospitalId: number,
    patientId: number,
   
}