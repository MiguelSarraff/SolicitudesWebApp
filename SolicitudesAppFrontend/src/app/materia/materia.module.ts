import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { MaterialModule } from '../material/material.module';
import { ListadoMateriaComponent } from './pages/listado-materia/listado-materia.component';
import { MateriaService } from './servicios/materia.service';
import { ModalMateriaComponent } from './modales/modal-materia/modal-materia.component';




@NgModule({
  declarations: [
    ListadoMateriaComponent,
    ModalMateriaComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ],
  providers: [
   MateriaService 
  ]
})
export class MateriaModule { }
