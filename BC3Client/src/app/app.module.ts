import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DatenService } from '../services/daten.service';
import {HttpModule} from '@angular/http';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [DatenService],
  bootstrap: [AppComponent]
})
export class AppModule { }
