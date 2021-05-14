import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DynamicData } from '../models/dynamicData';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';
import { Chart, ChartDataSets} from 'chart.js';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit
{
  public culturi = ["porumb", "grau", "floarea soarelui", "toate"];
  @ViewChild("barCanvas", { static: true }) barCanvas: ElementRef;  
  private barChart: Chart;
  xAx: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];
  yAx: number[] = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

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

  dynamicData: DynamicData = {
    temperature: 0,
    bloodOxygenLevel: 0,
    heartBeat: 0,
  };

  imageData: any;

  intervalId: any;

  constructor(private patientService: PatientService, private activatedRoute: ActivatedRoute) { }

  createPulsChart()
  {
    this.barChart = new Chart(this.barCanvas.nativeElement, {
      type: "line",
      data: {
        labels: this.xAx,
        datasets: [
          {
            data: this.yAx,
            fill: false,
            borderColor: 'red',
            label: 'Heart beats',
          }],
      },
      options: {
        scales: {
          yAxes: [
            {
              ticks: {
                beginAtZero: true,
                min: -10,
                max: 10
              }
            }
          ],
          xAxes: [
            {
              ticks:
              {
                beginAtZero: true,
                min: 0,
                max: 30
              }
            }
          ],
        }
      }
    });
  }

  ngOnInit()
  {
    var test: ChartDataSets = {
      data: [3]
    };

    this.createPulsChart();

    this.activatedRoute.queryParams.subscribe(params => {
      this.patientService.get(params.id).subscribe(patient => {
        this.patient = patient;

        console.log(this.patient);

        this.imageData = 'data:image/png;base64,' + this.patient.image;
      });
    });

    this.intervalId = setInterval(() => {
      this.patientService.getDynamicData(this.patient.id).subscribe(data => {
        this.dynamicData = data;

        if (this.yAx.length == 30) {
          this.yAx.shift();
        }
        this.yAx.push(this.dynamicData.heartBeat);
        this.barChart.update();
      });
   
    }, 200);
  }

  ngOnDestroy()
  {
    clearInterval(this.intervalId);
  }
}
