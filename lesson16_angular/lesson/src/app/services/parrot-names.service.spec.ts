import { TestBed } from '@angular/core/testing';

import { ParrotNamesService } from './parrot-names.service';

describe('ParrotNamesService', () => {
  let service: ParrotNamesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParrotNamesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
