import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Homepageload } from './homepageload';

describe('Homepageload', () => {
  let component: Homepageload;
  let fixture: ComponentFixture<Homepageload>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Homepageload],
    }).compileComponents();

    fixture = TestBed.createComponent(Homepageload);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
