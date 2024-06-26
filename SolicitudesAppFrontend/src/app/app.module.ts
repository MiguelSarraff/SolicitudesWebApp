import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UsuarioModule } from './usuario/usuario.module';
import { CuposComponent } from './cupos/cupos.component';
import { RevisionCalificacionesComponent } from './revision-calificaciones/revision-calificaciones.component';

@NgModule({
  declarations: [
    AppComponent,
    CuposComponent,
    RevisionCalificacionesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    UsuarioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
  })
export class AppModule { }
