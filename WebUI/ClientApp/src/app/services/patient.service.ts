import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from '../models/patient';

@Injectable({
  providedIn: 'root'
})

export class PatientService
{
  constructor(private http: HttpClient)
  {

  }

  public getAll()
  {
    return this.http.get<Patient[]>('/api/patient/all');
  }

  public get(id)
  {
    var url: string = '/api/patient/' + id;

    return this.http.get<any>(url);
  }

  public getDynamicData(id)
  {
    var url: string = '/api/patient/dynamic/' + id;

    return this.http.get<any>(url);
  }

  public update(patient)
  {
    return this.http.put('api/patient', patient);
  }

  public create(patient)
  {
    return this.http.post('api/patient', patient);
  }
}
