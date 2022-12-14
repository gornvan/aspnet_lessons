import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PeopleService } from '../services/people/people.service';
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
  ErrorMessage: String = "";
  constructor(private peopleService: PeopleService){}

  ngOnInit(){
    this.peopleService.getPeopleNames()
      .subscribe(
        (peopleNames: string[]) => {
          this.ListOfNames = peopleNames.join(', ');
        },
        error => {
          this.ErrorMessage = error.message;
          console.log(JSON.stringify(error));
        }
      );
  }
}
