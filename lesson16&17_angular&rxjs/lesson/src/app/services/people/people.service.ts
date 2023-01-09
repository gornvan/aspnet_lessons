import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../../models/person';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  constructor(private httpClient: HttpClient) { }
  getPeople() : Observable<Person[]> {
    return this.httpClient.get<Person[]>('assets/people.json');
  }
}
