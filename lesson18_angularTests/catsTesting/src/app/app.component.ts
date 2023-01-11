import { Component } from '@angular/core';
import { CatfoodService } from './services/catfood.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    CatfoodService
  ],
})
export class AppComponent {
  constructor(private catFoodService: CatfoodService){}

  title = 'catsTesting';
  food : string = "";

  ngOnInit() {
    this.food = this.catFoodService.requestFood();
  }
}
