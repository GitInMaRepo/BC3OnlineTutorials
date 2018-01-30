import { Component, OnInit } from '@angular/core';
import { DatenService } from '../../services/daten.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})
export class AddPersonComponent implements OnInit {


  vorname: string;
  nachname: string;

  constructor(private datenservice: DatenService) { }

  ngOnInit() {
  }

  OnSubmit() {
    console.log(this.vorname, this.nachname);
    this.datenservice.SaveData(this.vorname, this.nachname);
   }

}
