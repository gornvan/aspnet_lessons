import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ParrotNamesService {
  private names: string[] = [ "Bobby", "Jonny", "Nokia"];

  constructor() { }
  
  getNames(): string[] {
    return this.names;
  }

  addData(name: string){
    this.names.push(name);
  }
}
