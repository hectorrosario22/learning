import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecipeSignals } from './add-recipe-signals';

describe('AddRecipeSignals', () => {
  let component: AddRecipeSignals;
  let fixture: ComponentFixture<AddRecipeSignals>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRecipeSignals],
    }).compileComponents();

    fixture = TestBed.createComponent(AddRecipeSignals);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
