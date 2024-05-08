import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Carrera } from '../../interfaces/carrera';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { CarreraService } from '../../servicios/carrera.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';

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
  @ViewChild(MatPaginator) paginacionTabla!: MatPaginator;

  constructor(private _carreraServicio: CarreraService,
    private _compartidoService: CompartidoService){}

    obtenerCarreras(){
      this._carreraServicio.lista().subscribe({
        next: (data) =>{
          if(data.isExitoso)
            {
              this.dataSource = new MatTableDataSource(data.resultado)
              this.dataSource.paginator = this.paginacionTabla;
            }
            else
            this._compartidoService.mostrarAlerta(
          'No se encontraron datos',
          'Advertencia!'
          );
        },
        error: (e) => {}  
      });
    }  

  ngAfterViewInit(): void {
    this.obtenerCarreras();
  }
  ngOnInit(): void {
    this.dataSource.paginator = this.paginacionTabla;
  }

}
