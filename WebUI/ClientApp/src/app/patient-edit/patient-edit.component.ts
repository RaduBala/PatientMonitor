import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-edit',
  templateUrl: './patient-edit.component.html',
  styleUrls: ['./patient-edit.component.css']
})

export class PatientEditComponent implements OnInit
{
  patient: Patient =
  {
      id: 0,
      name: '',
      weight: 0,
      height: 0,
      image: null,
      address: null,
      age: 0,
  };

  dynamicData: any;

  imageData: any;

  constructor(private patientService: PatientService, private activatedRoute: ActivatedRoute, private router: Router)
  {

  }

  ngOnInit()
  {
    this.activatedRoute.queryParams.subscribe(params =>
    {
      this.patientService.get(params.id).subscribe(patient =>
      {
        this.patient = patient;

        this.imageData = 'data:image/png;base64,' + this.patient.image;
      });
    });
  }

  submit()
  {
    this.patientService.update(this.patient).subscribe(patient => this.router.navigate(['patient/all']));
  }
}
