import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { ListadoSeccionComponent } from './pages/listado-seccion/listado-seccion.component';
import { SeccionService } from './servicios/seccion.service';
import { MaterialModule } from '../material/material.module';
import { ModalSeccionComponent } from './modales/modal-seccion/modal-seccion.component';



@NgModule({
  declarations: [
    ListadoSeccionComponent,
    ModalSeccionComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ],

  providers: [
    SeccionService
  ]
})
export class SeccionModule { }
