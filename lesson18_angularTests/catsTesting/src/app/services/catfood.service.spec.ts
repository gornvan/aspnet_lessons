import { TestBed } from '@angular/core/testing';

import { CatfoodService } from './catfood.service';

describe('CatfoodService', () => {
  let service: CatfoodService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CatfoodService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
