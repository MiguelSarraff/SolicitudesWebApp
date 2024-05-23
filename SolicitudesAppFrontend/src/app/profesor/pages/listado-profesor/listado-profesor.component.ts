import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Profesor } from '../../interfaces/profesor';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ProfesorService } from '../../servicios/profesor.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import  Swal from 'sweetalert2';
import { filter } from 'rxjs';
import { ModalProfesorComponent } from '../../modales/modal-profesor/modal-profesor.component';

@Component({
  selector: 'app-listado-profesor',
  templateUrl: './listado-profesor.component.html',
  styleUrls: ['./listado-profesor.component.css']
})
export class ListadoProfesorComponent implements OnInit, AfterViewInit {


  displayedColumns: string[] = [

    'profesorNombres',
    'profesorApellidos',
    'cedula',
    'direccion',
    'telefono',
    'email',
    'genero',
    'estado',
    'acciones'
 ];

 dataInicial: Profesor[]=[];
 dataSource= new MatTableDataSource(this.dataInicial);
@ViewChild(MatPaginator) paginator!: MatPaginator;
 
constructor(
 
  private _profesorServicio:ProfesorService,
  private _compartidoServicio: CompartidoService,
  private dialog: MatDialog
){

}

ObtenerProfesores(){
  this._profesorServicio.lista().subscribe({
    next: (data) => {
      if(data.isExitoso)
        {
          this.dataSource = new MatTableDataSource(data.resultado);
          this.dataSource.paginator = this.paginator; 
        }
        else
        this._compartidoServicio.mostrarAlerta(
          'No se encontraron datos',
          'Advertencia!'
        );
      },
      error: (e) =>{
        this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
      }
  });
  }

  nuevoProfesor(){
    this.dialog
        .open(ModalProfesorComponent, {disableClose: true, width: '600px'})
        .afterClosed()
        .subscribe((resultado) =>{
          if (resultado ==='true') this.ObtenerProfesores();
        });

  }

  editarProfesor(profesor: Profesor) {
    this.dialog
        .open(ModalProfesorComponent, {disableClose: true, width:'600px',data: profesor })
        .afterClosed()
        .subscribe((resultado) =>{
          if(resultado === 'true') this.ObtenerProfesores();
        });

  }

  removerProfesor(profesor: Profesor){
    Swal.fire({
      title: 'Desea eliminar el Profesor?',
      text: profesor.profesorNombres+' '+profesor.profesorApellidos,
      icon:'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Si, eliminar', 
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No',
    }).then((resultado) => {
      if (resultado.isConfirmed){
        this._profesorServicio.eliminar(profesor.id).subscribe({
          next: (data) => {
            if(data.isExitoso) {
              this._compartidoServicio.mostrarAlerta('El medico fue eliminado', 'Completo');
              this.ObtenerProfesores();
            } else{
              this._compartidoServicio.mostrarAlerta('No se pudo eliminar el medico','Error!');
            } 
          },
          error: (e) => {
            this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
          }
        })
      }
    })
  }
  


  aplicarFiltroListado(event :Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }

  }



  
ngAfterViewInit(): void {
  this.dataSource.paginator = this.paginator;
}
ngOnInit(): void {
  this.ObtenerProfesores();
}


}


