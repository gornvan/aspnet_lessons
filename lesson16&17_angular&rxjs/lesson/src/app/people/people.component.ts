import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PeopleService } from '../services/people.service';
import { Person } from '../models/person';

@Component(
{
  providers: [PeopleService],
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent {
  ListOfNames: String = "";
  constructor(private peopleService: PeopleService){
  }

  ngOnInit(){
    this.peopleService.getPeople()
      .subscribe((people: Person[]) => {
        this.ListOfNames = people.map(person => person.Name).join(', ')
      });;
  }
}
