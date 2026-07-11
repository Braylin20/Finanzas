import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonSave } from './button-save';

describe('ButtonSave', () => {
  let component: ButtonSave;
  let fixture: ComponentFixture<ButtonSave>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ButtonSave],
    }).compileComponents();

    fixture = TestBed.createComponent(ButtonSave);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
