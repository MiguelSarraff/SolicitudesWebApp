import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { MaterialModule } from '../material/material.module';
import { CarreraService } from './servicios/carrera.service';
import { ListadoCarreraComponent } from './pages/listado-carrera/listado-carrera.component';



@NgModule({
  declarations: [
    ListadoCarreraComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ],

providers:[

  CarreraService
]

})
export class CarreraModule { }
