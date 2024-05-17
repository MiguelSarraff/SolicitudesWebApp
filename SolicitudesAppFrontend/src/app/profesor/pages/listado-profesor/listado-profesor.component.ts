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

    'ProfesorNombres',
    'ProfesorApellidos',
    'Cedula',
    'Direccion',
    'Telefono',
    'Email',
    'Genero',
    'FechaNacimiento',
    'estado',
    'acciones'
 ];

 dataInicial: Profesor[]=[];
 dataSource= new MatTableDataSource(this.dataInicial);
@ViewChild(MatPaginator) paginator!: MatPaginator;
 
constructor(
 
  private _profesorServicio:ProfesorService,
  private _compartidoService: CompartidoService,
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
        this._compartidoService.mostrarAlerta(
          'No se encontraron datos',
          'Advertencia!'
        );
      },
      error: (e) =>{
        this._compartidoService.mostrarAlerta(e.error.mensaje, 'Error!');
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

  editarProfesor(profesor: Profesor){

  }

  removerProfesor(profesor: Profesor){

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


