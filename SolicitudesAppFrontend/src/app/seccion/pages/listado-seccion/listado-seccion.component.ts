import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Seccion } from '../../interfaces/Seccion';
import { SeccionService } from '../../servicios/seccion.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ModalSeccionComponent } from '../../modales/modal-seccion/modal-seccion.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-listado-seccion',
  templateUrl: './listado-seccion.component.html',
  styleUrls: ['./listado-seccion.component.css']
})
export class ListadoSeccionComponent implements OnInit, AfterViewInit{

  displayedColumns: string[]=[
  
    'codigo',
    'edificio',
    'aula',  
    'horario',
    'nombreMateria',
    'nombreProfesor',
    'estado',
    'acciones',
  
  ];
  
  dataInicial: Seccion[] = [];
  dataSource = new MatTableDataSource(this.dataInicial);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  constructor(
      private _seccionServicio: SeccionService,
      private _compartidoServicio: CompartidoService,
      private dialog: MatDialog 
  ) {}
  
  ObtenerSecciones() {
    this._seccionServicio.lista().subscribe({
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

nuevaSeccion(){
  this.dialog
      .open(ModalSeccionComponent, {disableClose: true, width:'600px'})
      .afterClosed()
      .subscribe((resultado)=> {
       if (resultado=== 'true') this.ObtenerSecciones();

      })

}

editarSeccion(seccion: Seccion){
  this.dialog
        .open(ModalSeccionComponent, { disableClose: true, width: '600px', data: seccion })
        .afterClosed()
        .subscribe((resultado) => {
          if(resultado === 'true') this.ObtenerSecciones();
        });

}

removerSeccion(seccion: Seccion){
  Swal.fire({
    title: 'Desea Eliminar el Medico?',
    text: seccion.codigo+' '+seccion.nombreMateria,
    icon: 'warning',
    confirmButtonColor: '#3085d6',
    confirmButtonText:'Sí, eliminar',
    showCancelButton: true,
    cancelButtonColor: '#d33',
    cancelButtonText: 'No',
  }).then((resultado) => {
    if (resultado.isConfirmed) {
      this._seccionServicio.eliminar(seccion.id).subscribe({
        next: (data) => {
          if(data.isExitoso) {
            this._compartidoServicio.mostrarAlerta('La materia fue eliminada', 'Completo');
            this.ObtenerSecciones();
          }
          else {
            this._compartidoServicio.mostrarAlerta('No se pudo eliminar la materia','Error!');
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
    this.ObtenerSecciones();
  }


}



