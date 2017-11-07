import { Component, OnInit } from '@angular/core';
import {DatenService} from '../services/daten.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  daten: string;

  constructor (private datenservice: DatenService) { }
  ngOnInit() {
    this.daten = this.datenservice.LeseDaten();
   }
}
