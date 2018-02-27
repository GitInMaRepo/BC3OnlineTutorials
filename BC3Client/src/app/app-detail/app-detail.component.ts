import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/model';
import { DatenService } from '../../services/daten.service';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-app-detail',
  templateUrl: './app-detail.component.html',
  styleUrls: ['./app-detail.component.css']
})
export class AppDetailComponent implements OnInit {
  daten: Person;

  constructor(private datenservice: DatenService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.daten = new Person(undefined, undefined, undefined);
    this.route.paramMap
    .switchMap((params: ParamMap) => this.datenservice.GetSinglePerson(+params.get('id')))
    .subscribe(result => this.daten = result);
  }

}
