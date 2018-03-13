import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/model';
import { DatenService } from '../../services/daten.service';

@Component({
  selector: 'app-random-person',
  templateUrl: './random-person.component.html',
  styleUrls: ['./random-person.component.css']
})
export class RandomPersonComponent implements OnInit {
  person: Person;

  constructor (private datenservice: DatenService) { }

  ngOnInit() {
    this.datenservice.GetRandomPerson().subscribe(result => this.person = result);
   }

}
