import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParrotComponent } from './parrot.component';

describe('ParrotComponent', () => {
  let component: ParrotComponent;
  let fixture: ComponentFixture<ParrotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParrotComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParrotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
