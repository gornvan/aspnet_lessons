import { CatfoodService } from "src/app/services/catfood.service";


export class StubCatfoodService extends CatfoodService {
    constructor() { super(); }
  
    food = '';
    requestFoodCalled :number = 0;

    setFood(food: string){
      this.food = food;
    }

    override requestFood() : string {
      this.requestFoodCalled += 1;
      return this.food;
    }
  }