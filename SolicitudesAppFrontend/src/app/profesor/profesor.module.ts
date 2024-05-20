import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { MaterialModule } from '../material/material.module';
import { ListadoProfesorComponent } from './pages/listado-profesor/listado-profesor.component';
import { ProfesorService } from './servicios/profesor.service';
import { ModalProfesorComponent } from './modales/modal-profesor/modal-profesor.component';



@NgModule({
  declarations: [
    ListadoProfesorComponent,
    ModalProfesorComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ], 

  providers: [
    ProfesorService
  ]
})
export class ProfesorModule { }
