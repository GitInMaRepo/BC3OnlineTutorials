import { Component } from '@angular/core';
import { Person } from '../../models/model';


@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent {

  anreden = ['Herr', 'Frau',
            'Eure Eminenz', 'Eheleute'];

  model = new Person(this.anreden[2], 'Peter', 'Fischer');

  submitted = false;

  onSubmit() { this.submitted = true; }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }
}
