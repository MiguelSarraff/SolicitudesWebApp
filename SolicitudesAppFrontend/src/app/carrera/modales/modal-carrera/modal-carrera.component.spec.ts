import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalCarreraComponent } from './modal-carrera.component';

describe('ModalCarreraComponent', () => {
  let component: ModalCarreraComponent;
  let fixture: ComponentFixture<ModalCarreraComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalCarreraComponent]
    });
    fixture = TestBed.createComponent(ModalCarreraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
