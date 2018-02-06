import { Component, OnInit } from '@angular/core';
import {DatenService} from '../../services/daten.service';
import { Person } from '../../models/model';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})

export class OverviewComponent implements OnInit {
  title = 'app';
  daten: Person;
  allDaten: Person[];

  constructor (private datenservice: DatenService) { }
  ngOnInit() {
    this.daten = new Person();
    this.allDaten = [];
    this.daten.vorname = 'lese gerade daten..';
    this.datenservice.GetData().subscribe(result => this.daten = result);
    this.datenservice.GetAllData().subscribe(result => this.allDaten = result);
   }

   OnSubmit() {
    this.datenservice.SaveData('Donald', 'Trump');
   }
}
