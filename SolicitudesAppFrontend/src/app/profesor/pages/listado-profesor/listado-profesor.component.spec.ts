import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoProfesorComponent } from './listado-profesor.component';

describe('ListadoProfesorComponent', () => {
  let component: ListadoProfesorComponent;
  let fixture: ComponentFixture<ListadoProfesorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoProfesorComponent]
    });
    fixture = TestBed.createComponent(ListadoProfesorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
