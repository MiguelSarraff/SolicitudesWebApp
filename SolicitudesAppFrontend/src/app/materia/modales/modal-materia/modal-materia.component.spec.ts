import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalMateriaComponent } from './modal-materia.component';

describe('ModalMateriaComponent', () => {
  let component: ModalMateriaComponent;
  let fixture: ComponentFixture<ModalMateriaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalMateriaComponent]
    });
    fixture = TestBed.createComponent(ModalMateriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
