import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalEstudianteComponent } from './modal-estudiante.component';

describe('ModalEstudianteComponent', () => {
  let component: ModalEstudianteComponent;
  let fixture: ComponentFixture<ModalEstudianteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalEstudianteComponent]
    });
    fixture = TestBed.createComponent(ModalEstudianteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
