import { Component, OnInit } from '@angular/core';
import {DatenService} from '../services/daten.service';
import { Person } from '../models/model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  daten: Person;
  allDaten: Person[];

  constructor (private datenservice: DatenService) { }
  ngOnInit() {
    this.daten = new Person();
    this.allDaten = [];
    this.daten.data = 'lese gerade daten..';
    this.datenservice.GetData().subscribe(result => this.daten = result);
    this.datenservice.GetAllData().subscribe(result => this.allDaten = result);
   }
}
