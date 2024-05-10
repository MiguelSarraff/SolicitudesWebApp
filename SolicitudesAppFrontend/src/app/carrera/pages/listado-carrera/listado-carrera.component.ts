import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Carrera } from '../../interfaces/carrera';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { CarreraService } from '../../servicios/carrera.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalCarreraComponent } from '../../modales/modal-carrera/modal-carrera.component';
import  Swal from 'sweetalert2';
import { filter } from 'rxjs';



@Component({
  selector: 'app-listado-carrera',
  templateUrl: './listado-carrera.component.html',
  styleUrls: ['./listado-carrera.component.css']
})
export class ListadoCarreraComponent implements OnInit, AfterViewInit{

  displayedColumns: string[] = [
    'CarreraNombre',
    'CarreraCodigo',
    'Estado',
    'acciones'
  ];

  dataInicial: Carrera[]=[];
  dataSource = new MatTableDataSource(this.dataInicial);
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _carreraServicio: CarreraService,
    private _compartidoService: CompartidoService,
    private dialog: MatDialog
    ){}

    nuevoCarrera() {
      this.dialog
        .open(ModalCarreraComponent, { disableClose: true, width: '400px' })
        .afterClosed()
        .subscribe((resultado) => {
          if (resultado === 'true') this.obtenerCarreras();
        });
    }
  
    editarCarrera(carrera: Carrera) {
      this.dialog
        .open(ModalCarreraComponent, {
          disableClose: true,
          width: '400px',
          data: carrera,
        })
        .afterClosed()
        .subscribe((resultado) => {
          if (resultado === 'true') this.obtenerCarreras();
        });
    }
  
    obtenerCarreras() {
      this._carreraServicio.lista().subscribe({
        next: (data) => {
          if (data.isExitoso) {
            this.dataSource = new MatTableDataSource(data.resultado);
            this.dataSource.paginator = this.paginator;
          } else
            this._compartidoService.mostrarAlerta(
              'No se encontraron datos',
              'Advertencia!'
            );
        },
        error: (e) => {
          this._compartidoService.mostrarAlerta(e.error.mensaje, 'Error!');
        },
      });
    }
  
    removerCarrera(carrera: Carrera) {
      Swal.fire({
        title: 'Desea Eliminar la Carrera?',
        text: carrera.CarreraNombre,
        icon: 'warning',
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'Sí, eliminar',
        showCancelButton: true,
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
      }).then((resultado) => {
        if (resultado.isConfirmed) {
          this._carreraServicio.eliminar(carrera.id).subscribe({
            next: (data) => {
              if (data.isExitoso) {
                this._compartidoService.mostrarAlerta(
                  'La carrera fue eliminada',
                  'Completo'
                );
                this.obtenerCarreras();
              } else {
                this._compartidoService.mostrarAlerta(
                  'No se pudo eliminar la carrera',
                  'Error!'
                );
              }
            },
            error: (e) => {
               this._compartidoService.mostrarAlerta(e.error.mensaje, 'Error!');
            },
          });
        }
      });
    }
  
    aplicarFiltroListado(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
      if (this.dataSource.paginator) {
        this.dataSource.paginator.firstPage();
      }
    }

    

  ngAfterViewInit(): void {
    this.obtenerCarreras();
  }
  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
  }

}
