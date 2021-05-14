import { BrowserModule } from '@angular/platform-browser';
import { Component, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { PatientService } from './services/patient.service';
import { PatientListComponent } from './patient-list/patient-list.component';
import { PatientEditComponent } from './patient-edit/patient-edit.component';
import { PatientCreateComponent } from './patient-create/patient-create.component';
import { PatientViewComponent } from './patient-view/patient-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PatientListComponent,
    PatientEditComponent,
    PatientCreateComponent,
    PatientViewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PatientListComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'patient/all', component: PatientListComponent },
      { path: 'patient/edit', component: PatientEditComponent },
      { path: 'patient/create', component: PatientCreateComponent },
      { path: 'patient/view', component: PatientViewComponent },
    ])
  ],
  providers: [
    PatientService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
