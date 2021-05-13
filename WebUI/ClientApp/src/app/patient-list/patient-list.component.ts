import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit
{
  patients: Patient[];

  constructor(private patientService: PatientService, private router: Router)
  {

  }

  ngOnInit()
  {
    this.patientService.getAll().subscribe(patients => this.patients = patients);
  }

  onView(patient)
  {
    this.router.navigate(['/patient/edit'],
    {
      queryParams: {
          id: patient.id,
      }
    });
  }
}
