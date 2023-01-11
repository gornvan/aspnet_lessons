
export class StubCatfoodService {
    constructor() {}
  
    food = '';
    requestFoodCalled :number = 0;

    setFood(food: string){
      this.food = food;
    }

    requestFood() : string {
      this.requestFoodCalled += 1;
      return this.food;
    }
  }