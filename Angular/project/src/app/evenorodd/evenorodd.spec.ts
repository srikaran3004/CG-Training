import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Evenorodd } from './evenorodd';

describe('Evenorodd', () => {
  let component: Evenorodd;
  let fixture: ComponentFixture<Evenorodd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Evenorodd],
    }).compileComponents();

    fixture = TestBed.createComponent(Evenorodd);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
