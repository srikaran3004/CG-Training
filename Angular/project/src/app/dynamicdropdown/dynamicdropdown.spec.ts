import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dynamicdropdown } from './dynamicdropdown';

describe('Dynamicdropdown', () => {
  let component: Dynamicdropdown;
  let fixture: ComponentFixture<Dynamicdropdown>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Dynamicdropdown],
    }).compileComponents();

    fixture = TestBed.createComponent(Dynamicdropdown);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
