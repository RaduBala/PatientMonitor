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
  public chart: any;

  patient: Patient =
  {
      id: 0,
      name: '',
      weight: 0,
      height: 0,
      image: null,
  };

  dynamicData: any;

  imageData: any;

  intervalId: any;

  constructor(private patientService: PatientService, private route: ActivatedRoute, private router: Router)
  {

  }

  ngOnInit()
  {
    this.route.queryParams.subscribe(params =>
    {
      this.patientService.get(params.id).subscribe(patient =>
      {
        this.patient = patient;

        this.imageData = 'data:image/png;base64,' + this.patient.image;
      });
    });

    this.intervalId = setInterval(() =>
    {
      this.patientService.getDynamicData(this.patient.id).subscribe();
    }, 200);
  }

  periodicRequestDynamicData()
  {

  }

  ngOnDestroy() {
    clearInterval(this.intervalId);
  }

  submit()
  {
    this.patientService.update(this.patient).subscribe(patient => this.router.navigate(['patient/all']));
  }
}
