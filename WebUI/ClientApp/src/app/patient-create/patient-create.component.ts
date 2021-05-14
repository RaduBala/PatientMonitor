import { Component, OnInit } from '@angular/core';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-create',
  templateUrl: './patient-create.component.html',
  styleUrls: ['./patient-create.component.css']
})
export class PatientCreateComponent implements OnInit
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

  imgURL: any;

  selectedFile: any;

  constructor(private patientService: PatientService) { }

  ngOnInit()
  {
  }

  onPhotoSelected(event)
  {
    this.selectedFile = <File>event.target.files[0];

    var reader = new FileReader();
    reader.readAsDataURL(this.selectedFile);
    reader.onload = (_event) =>
    {
      this.imgURL = reader.result;
    }
  }

  submit()
  {
    console.log(this.selectedFile);

    const formData = new FormData();

    formData.append('image', this.selectedFile, this.selectedFile.name);
    formData.append('name', this.patient.name);
    formData.append('weight', this.patient.weight.toString());
    formData.append('height', this.patient.height.toString());
    formData.append('age', this.patient.age.toString());
    formData.append('address', this.patient.address);

    this.patientService.create(formData).subscribe();
  }
}
