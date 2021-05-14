import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit
{
  patient: Patient =
    {
      id: 0,
      name: '',
      weight: 0,
      height: 0,
      age: 0,
      address: null,
      image: null,
    };

  dynamicData: any;

  imageData: any;

  intervalId: any;

  constructor(private patientService: PatientService, private activatedRoute: ActivatedRoute) { }

  ngOnInit()
  {
    this.activatedRoute.queryParams.subscribe(params => {
      this.patientService.get(params.id).subscribe(patient => {
        this.patient = patient;

        console.log(this.patient);

        this.imageData = 'data:image/png;base64,' + this.patient.image;
      });
    });

    this.intervalId = setInterval(() => {
      this.patientService.getDynamicData(this.patient.id).subscribe();
    }, 200);
  }

  ngOnDestroy()
  {
    clearInterval(this.intervalId);
  }
}
