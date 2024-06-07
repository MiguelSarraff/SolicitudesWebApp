import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoSeccionComponent } from './listado-seccion.component';

describe('ListadoSeccionComponent', () => {
  let component: ListadoSeccionComponent;
  let fixture: ComponentFixture<ListadoSeccionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoSeccionComponent]
    });
    fixture = TestBed.createComponent(ListadoSeccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
