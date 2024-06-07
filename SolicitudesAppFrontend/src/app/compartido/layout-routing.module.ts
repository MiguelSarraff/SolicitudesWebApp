import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SolicitudesComponent } from '../solicitudes/pages/solicitudes/solicitudes.component';
import { PerfilComponent } from '../perfil/pages/perfil/perfil.component';
import { ListadoCarreraComponent } from '../carrera/pages/listado-carrera/listado-carrera.component';
import {} from '../carrera/carrera.module';
import {} from '../profesor/profesor.module';
import {} from '../materia/materia.module';
import {} from '../estudiante/estudiante.module';
import {} from  '../seccion/seccion.module'
import { ListadoProfesorComponent } from '../profesor/pages/listado-profesor/listado-profesor.component';
import { ListadoMateriaComponent } from '../materia/pages/listado-materia/listado-materia.component';
import { ListadoEstudianteComponent } from '../estudiante/pages/listado-estudiante/listado-estudiante.component';
import { ListadoSeccionComponent } from '../seccion/pages/listado-seccion/listado-seccion.component';


const routes: Routes = [
 {
   path: '', component: LayoutComponent,
   children: [
    {path: 'dashboard',component: DashboardComponent, pathMatch: 'full'},
    {path: 'carreras', component: ListadoCarreraComponent, pathMatch: 'full'},
    {path: 'solicitudes',component:SolicitudesComponent,pathMatch:'full'},
    {path: 'perfil', component:PerfilComponent,pathMatch:'full'},
    {path: 'Profesores', component:ListadoProfesorComponent, pathMatch: 'full'},
    {path: 'materias', component:ListadoMateriaComponent, pathMatch: 'full'},
    {path: 'estudiantes', component:ListadoEstudianteComponent, pathMatch: 'full'},
    {path: 'secciones', component:ListadoSeccionComponent, pathMatch: 'full'},
    {path: '**',redirectTo: '', pathMatch:'full'}
   ]
 } 

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class LayoutRoutingModule { }
