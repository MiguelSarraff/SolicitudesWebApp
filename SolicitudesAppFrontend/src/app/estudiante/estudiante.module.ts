import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadoEstudianteComponent } from './pages/listado-estudiante/listado-estudiante.component';
import { CompartidoModule } from '../compartido/compartido.module';
import { MaterialModule } from '../material/material.module';
import { EstudianteService } from './servicios/estudiante.service';
import { ModalEstudianteComponent } from './modales/modal-estudiante/modal-estudiante.component';



@NgModule({
  declarations: [
    ListadoEstudianteComponent,
    ModalEstudianteComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ],
  providers: [
    EstudianteService

  ]
})
export class EstudianteModule { }
