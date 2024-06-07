import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalSeccionComponent } from './modal-seccion.component';

describe('ModalSeccionComponent', () => {
  let component: ModalSeccionComponent;
  let fixture: ComponentFixture<ModalSeccionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalSeccionComponent]
    });
    fixture = TestBed.createComponent(ModalSeccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
