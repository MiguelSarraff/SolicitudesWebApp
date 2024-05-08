import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoCarreraComponent } from './listado-carrera.component';

describe('ListadoCarreraComponent', () => {
  let component: ListadoCarreraComponent;
  let fixture: ComponentFixture<ListadoCarreraComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoCarreraComponent]
    });
    fixture = TestBed.createComponent(ListadoCarreraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
