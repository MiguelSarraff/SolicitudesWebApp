import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Materia } from '../../interfaces/materia';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MateriaService } from '../../servicios/materia.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalMateriaComponent } from '../../modales/modal-materia/modal-materia.component';
import  Swal from 'sweetalert2';


@Component({
  selector: 'app-listado-materia',
  templateUrl: './listado-materia.component.html',
  styleUrls: ['./listado-materia.component.css']
})
export class ListadoMateriaComponent implements OnInit, AfterViewInit{


displayedColumns: string[]=[
  
  'materiaNombre',
  'materiaCodigo' ,
  'materiaCreditos',  
  'carreraNombre',
  'estado',
  'acciones'
];

dataInicial: Materia[] = [];
dataSource = new MatTableDataSource(this.dataInicial);
@ViewChild(MatPaginator) paginator!: MatPaginator;

constructor(
    private _materiaServicio: MateriaService,
    private _compartidoServicio: CompartidoService,
    private dialog: MatDialog 
) {}

ObtenerMaterias() {
  this._materiaServicio.lista().subscribe({
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

nuevaMateria() {
  this.dialog
      .open(ModalMateriaComponent, {disableClose: true, width:'600px'})
      .afterClosed()
      .subscribe((resultado)=> {
       if (resultado=== 'true') this.ObtenerMaterias();

      })
}

editarMateria(materia: Materia){
  this.dialog
        .open(ModalMateriaComponent, { disableClose: true, width: '600px', data: materia })
        .afterClosed()
        .subscribe((resultado) => {
          if(resultado === 'true') this.ObtenerMaterias();
        });
}

removerMateria(materia: Materia){
  Swal.fire({
    title: 'Desea Eliminar el Medico?',
    text: materia.materiaNombre+' '+materia.materiaCodigo,
    icon: 'warning',
    confirmButtonColor: '#3085d6',
    confirmButtonText:'Sí, eliminar',
    showCancelButton: true,
    cancelButtonColor: '#d33',
    cancelButtonText: 'No',
  }).then((resultado) => {
    if (resultado.isConfirmed) {
      this._materiaServicio.eliminar(materia.id).subscribe({
        next: (data) => {
          if(data.isExitoso) {
            this._compartidoServicio.mostrarAlerta('La materia fue eliminada', 'Completo');
            this.ObtenerMaterias();
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
  this.dataSource.paginator = this.paginator
  }
  ngOnInit(): void {
    this.ObtenerMaterias();

}


}