import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DatenService } from '../services/daten.service';
import {HttpModule} from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { AppDetailComponent } from './app-detail/app-detail.component';

const appRoutes: Routes = [
  { path: 'person/:id', component: AppDetailComponent },
  { path: '', component: AppComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    AppDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [DatenService],
  bootstrap: [AppComponent]
})
export class AppModule { }
