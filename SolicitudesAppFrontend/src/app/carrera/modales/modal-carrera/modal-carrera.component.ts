import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Carrera } from '../../interfaces/carrera';
import { CarreraService } from '../../servicios/carrera.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';

@Component({
  selector: 'app-modal-carrera',
  templateUrl: './modal-carrera.component.html',
  styleUrls: ['./modal-carrera.component.css']
})
export class ModalCarreraComponent implements OnInit{
formCarrera: FormGroup;
titulo: string = "Agregar carrera";
nombreBoton: string = "Guardar";


constructor(private modal: MatDialogRef<ModalCarreraComponent>,
            @Inject(MAT_DIALOG_DATA) public datosCarrera: Carrera,
            private fb: FormBuilder,
            private _carreraServicio: CarreraService,
            private _compartidoServicio: CompartidoService){
this.formCarrera =  this.fb.group({
  carreraNombre: ['',Validators.required],
  carreraCodigo: ['',Validators.required],
  estado:['1',Validators.required] 
});

if(this.datosCarrera != null) {
  this.titulo = 'Editar carrera';
  this.nombreBoton = 'Actualizar';
 }   

}

  ngOnInit(): void {
    if(this.datosCarrera !=null)
  {
    this.formCarrera.patchValue({ 
    CarreraNombre: this.datosCarrera.CarreraNombre,
    CarreraCodigo: this.datosCarrera.CarreraCodigo,
    Estado: this.datosCarrera.estado.toString()
   })
  }
 }

 crearModificarCarrera(){
  const carrera: Carrera = {
    id: this.datosCarrera == null ? 0 : this.datosCarrera.id,
    CarreraNombre: this.formCarrera.value.carreraNombre,
    CarreraCodigo: this.formCarrera.value.carreraCodigo,
    estado: parseInt(this.formCarrera.value.estado)
  }
  if(this.datosCarrera == null)
    {
      // Crear Carrera
      this._carreraServicio.crear(carrera).subscribe({
        next: (data) =>{
          if(data.isExitoso)
            {
              this._compartidoServicio.mostrarAlerta('La carrera ha sido registrada con exito!',
                                                     'Completo');
              this.modal.close("true");                                       
            }
            else
            this._compartidoServicio.mostrarAlerta('No se pudo crear la carrera',
                                                   'Error!');

        },
        error: (e) => {
          this._compartidoServicio.mostrarAlerta(e.error.mensaje,
            'Error!');
        }
      })

    } 
    else 
    {
       // Editar/Actualizar Carrera
       this._carreraServicio.editar(carrera).subscribe({
        next: (data) => {
          if(data.isExitoso)
            {
              this._compartidoServicio.mostrarAlerta('La carrera ha sido actualizada con exito!',
                                                     'Completo');
              this.modal.close("true");                                       
            }
            else
            this._compartidoServicio.mostrarAlerta('No se pudo actualizar la carrera',
                                                   'Error!');

        },
        error: (e) => {
          this._compartidoServicio.mostrarAlerta(e.error.mensaje,
                                                       'Error!');
        }
      })
    }
 }
 
} 




