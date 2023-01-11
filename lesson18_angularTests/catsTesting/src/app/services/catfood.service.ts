import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CatfoodService {
  constructor() { }

  requestFood() : string {
    return 'Meat';
  }
}
