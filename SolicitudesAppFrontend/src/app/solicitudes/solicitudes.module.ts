import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { MaterialModule } from '../material/material.module';
import { SolicitudesComponent } from './pages/solicitudes/solicitudes.component';



@NgModule({
  declarations: [
    SolicitudesComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ]
})
export class SolicitudesModule { }
