import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { DatenService } from '../services/daten.service';
import {HttpModule} from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { AppDetailComponent } from './app-detail/app-detail.component';
import { OverviewComponent } from './overview/overview.component';
import { AddPersonComponent } from './add-person/add-person.component';
import { PersonFormComponent } from './person-form/person-form.component';
import { RandomPersonComponent } from './random-person/random-person.component';

const appRoutes: Routes = [
  { path: 'person/:id', component: AppDetailComponent },
  { path: 'add', component: AddPersonComponent },
  { path: '', component: OverviewComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    AppDetailComponent,
    OverviewComponent,
    AddPersonComponent,
    PersonFormComponent,
    RandomPersonComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [DatenService],
  bootstrap: [AppComponent]
})
export class AppModule { }
