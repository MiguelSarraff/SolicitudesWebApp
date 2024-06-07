import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Estudiante } from '../../interfaces/estudiante';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { EstudianteService } from '../../servicios/estudiante.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalEstudianteComponent } from '../../modales/modal-estudiante/modal-estudiante.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-listado-estudiante',
  templateUrl: './listado-estudiante.component.html',
  styleUrls: ['./listado-estudiante.component.css']
})
export class ListadoEstudianteComponent implements OnInit, AfterViewInit {


  displayedColumns: string[]=[
  
    'estudianteNombres',
    'estudianteApellidos',
    'nombreUsuario',  
    'cedula',
    'direccion',
    'telefono',
    'email',
    'genero',
    'estado',
    'acciones'
  ];
  
  dataInicial: Estudiante[] = [];
  dataSource = new MatTableDataSource(this.dataInicial);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  constructor(
      private _estudianteServicio: EstudianteService,
      private _compartidoServicio: CompartidoService,
      private dialog: MatDialog 
  ) {}
  
  ObtenerEstudiantes() {
    this._estudianteServicio.lista().subscribe({
      next: (data) => {
        if (data.isExitoso) {
          this.dataSource = new MatTableDataSource(data.resultado);
          this.dataSource.paginator = this.paginator;
        } else
          this._compartidoServicio.mostrarAlerta(
            'No se encontraron datos',
            'Advertencia!'
          );
      },
      error: (e) => {
         this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
      },
    });
  }

nuevoEstudiante(){
  this.dialog
  .open(ModalEstudianteComponent, {disableClose: true, width: '600px'})
  .afterClosed()
  .subscribe((resultado) =>{
    if (resultado ==='true') this.ObtenerEstudiantes();
  });

}

editarEstudiante(estudiante: Estudiante){
  this.dialog
  .open(ModalEstudianteComponent, {disableClose: true, width:'600px',data: estudiante })
  .afterClosed()
  .subscribe((resultado) =>{
    if(resultado === 'true') this.ObtenerEstudiantes();
  });


}

removerEstudiante(estudiante: Estudiante){
  Swal.fire({
    title: 'Desea eliminar el Estudiante?',
    text: estudiante.estudianteNombres+' '+estudiante.estudianteApellidos,
    icon:'warning',
    confirmButtonColor: '#3085d6',
    confirmButtonText: 'Si, eliminar', 
    showCancelButton: true,
    cancelButtonColor: '#d33',
    cancelButtonText: 'No',
  }).then((resultado) => {
    if (resultado.isConfirmed){
      this._estudianteServicio.eliminar(estudiante.id).subscribe({
        next: (data) => {
          if(data.isExitoso) {
            this._compartidoServicio.mostrarAlerta('El Estudiante fue eliminado', 'Completo');
            this.ObtenerEstudiantes();
          } else{
            this._compartidoServicio.mostrarAlerta('No se pudo eliminar el Estudiante','Error!');
          } 
        },
        error: (e) => {
          this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
        }
      })
    }
  })

}

aplicarFiltroListado(event: Event) {
  const filterValue = (event.target as HTMLInputElement).value;
  this.dataSource.filter = filterValue.trim().toLowerCase();
  if (this.dataSource.paginator) {
    this.dataSource.paginator.firstPage();
  }
}



  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit(): void {
    this.ObtenerEstudiantes();
  }


}
