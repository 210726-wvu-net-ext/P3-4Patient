import { Time } from "@angular/common";

export interface Review {
    id: number,
    patientid: string,
    comfort: number,
    dateposted: Time, // ??
    message: string,
    hospitalid: number,
    accommodationid: number,
    nursingid: number,
    covidid: number,
    cleanlinessid: number
   
}