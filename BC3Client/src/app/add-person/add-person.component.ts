import { Component, OnInit } from '@angular/core';
import { DatenService } from '../../services/daten.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})
export class AddPersonComponent implements OnInit {


  vorname: string;
  nachname: string;

  constructor(private datenservice: DatenService, private router: Router) { }

  ngOnInit() {
  }

  OnSubmit() {
    console.log(this.vorname, this.nachname);
    this.datenservice.SaveData(this.vorname, this.nachname)
    .subscribe((data) => {
      this.router.navigate(['./']);
    });
   }
}
