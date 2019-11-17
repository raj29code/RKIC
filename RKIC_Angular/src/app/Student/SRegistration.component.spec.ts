import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SRegistrationComponent } from './SRegistration.component';

describe('SRegistrationComponent', () => {
  let component: SRegistrationComponent;
  let fixture: ComponentFixture<SRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
