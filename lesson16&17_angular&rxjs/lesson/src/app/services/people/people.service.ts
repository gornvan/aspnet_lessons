import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../../models/person';
import { map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  constructor(private httpClient: HttpClient) { }

  getPeople() : Observable<Person[]> {
    return this.httpClient.get<Person[]>('assets/WRONGpeople.json');
  }

  getPeopleNames(): Observable<string[]>
  {
    return this.getPeople().pipe(map(
      people =>{
        return people.map(p => p.Name);
      }
    ))
    ;
  }

}
