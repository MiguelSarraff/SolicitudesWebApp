import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoMateriaComponent } from './listado-materia.component';

describe('ListadoMateriaComponent', () => {
  let component: ListadoMateriaComponent;
  let fixture: ComponentFixture<ListadoMateriaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoMateriaComponent]
    });
    fixture = TestBed.createComponent(ListadoMateriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
