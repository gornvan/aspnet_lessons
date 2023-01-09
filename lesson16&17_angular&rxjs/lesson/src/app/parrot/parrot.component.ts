import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParrotNamesService } from '../services/parrot/parrot-names.service';

@Component({
  providers: [ParrotNamesService],
  selector: 'app-parrot',
  templateUrl: './parrot.component.html',
  styleUrls: ['./parrot.component.css']
})
export class ParrotComponent {
  nameFromRoute: string = "";
  constructor(private parrotNamesService: ParrotNamesService, activeRoute: ActivatedRoute) {
    this.nameFromRoute = activeRoute.snapshot.params['name'];
  }

  name: string = "";
  wingSpan: number = 0;

  ngOnInit(): void {
    this.name = this.nameFromRoute || this.parrotNamesService.getNames()[0];
    this.wingSpan = Math.floor(Math.random()*100);
    
    console.log(this.name);
  }

  onSubmit(): void {
    console.log(this.name);
    console.log(this.wingSpan);

    this.name = this.name + "!"
    this.wingSpan = this.wingSpan * 2
  }
}
