import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { MaterialModule } from '../material/material.module';
import { PerfilComponent } from './pages/perfil/perfil.component';



@NgModule({
  declarations: [
    PerfilComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ]
})
export class PerfilModule { }
