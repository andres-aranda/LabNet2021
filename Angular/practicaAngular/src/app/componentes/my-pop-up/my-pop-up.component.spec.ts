import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyPopUpComponent } from './my-pop-up.component';

describe('MyPopUpComponent', () => {
  let component: MyPopUpComponent;
  let fixture: ComponentFixture<MyPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
