import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SolicitudesComponent } from '../solicitudes/pages/solicitudes/solicitudes.component';
import { PerfilComponent } from '../perfil/pages/perfil/perfil.component';
import { ListadoCarreraComponent } from '../carrera/pages/listado-carrera/listado-carrera.component';
import {} from '../carrera/carrera.module';


const routes: Routes = [
 {
   path: '', component: LayoutComponent,
   children: [
    {path: 'dashboard',component: DashboardComponent, pathMatch: 'full'},
    {path: 'carreras', component: ListadoCarreraComponent, pathMatch: 'full'},
    {path: 'solicitudes',component:SolicitudesComponent,pathMatch:'full'},
    {path: 'perfil', component:PerfilComponent,pathMatch:'full'},
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
