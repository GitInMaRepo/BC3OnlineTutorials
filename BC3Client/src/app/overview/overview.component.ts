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
  allDaten: Person[];

  constructor (private datenservice: DatenService) { }
  ngOnInit() {
    this.allDaten = [];
    this.datenservice.GetAllData().subscribe(result => this.allDaten = result);
   }
}
