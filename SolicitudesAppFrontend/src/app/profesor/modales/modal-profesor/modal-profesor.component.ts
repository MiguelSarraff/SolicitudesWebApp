import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Profesor } from '../../interfaces/profesor';
import { ProfesorService } from '../../servicios/profesor.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';

@Component({
  selector: 'app-modal-profesor',
  templateUrl: './modal-profesor.component.html',
  styleUrls: ['./modal-profesor.component.css']
})
export class ModalProfesorComponent implements OnInit{

formProfesor: FormGroup;
titulo: string = "Agregar";
nombreBoton: string = "Guardar";

constructor(
  private modal: MatDialogRef<ModalProfesorComponent>,
  @Inject(MAT_DIALOG_DATA) public datosProfesor: Profesor,
  private fb: FormBuilder,
  private _profesorServicio: ProfesorService,
  private _compartidoServicio: CompartidoService
){
  this.formProfesor = this.fb.group({
 ProfesorNombres: ['',Validators.required],
 ProfesorApellidos: ['',Validators.required],  
 Cedula: ['',],
 Direccion:['',],
 Telefono:['',],
 Email:['',],
 Genero:['M',],
 FechaNacimiento:['',Validators.required],
 estado:['1',Validators.required]
});
if(this.datosProfesor !=null)
{ 
   this.titulo ="Editar";
   this.nombreBoton = "Actualizar";
}
}

  ngOnInit(): void {
    if(this.datosProfesor !=null)
      {
        this.formProfesor.patchValue({
          ProfesorNombres: this.datosProfesor.ProfesorNombres,
          ProfesorApellidos: this.datosProfesor.ProfesorApellidos,
          Cedula: this.datosProfesor.Direccion,
          Direccion: this.datosProfesor.Direccion,
          Telefono: this.datosProfesor.Telefono,
          Email: this.datosProfesor.email,
          Genero: this.datosProfesor.genero,
          FechaNacimiento: this.datosProfesor.fechaNacimiento,
          estado: this.datosProfesor.estado.toString()
          
        })
      }
  }

crearModificarProfesor(){

 const profesor: Profesor = {
    ProfesorId: this.datosProfesor == null ? 0 :this.datosProfesor.ProfesorId,
    ProfesorNombres: this.formProfesor.value.profesorNombres,
    ProfesorApellidos: this.formProfesor.value.profesorApellidos,
    Cedula: this.formProfesor.value.cedula,
    Direccion: this.formProfesor.value.direccion,
    Telefono: this.formProfesor.value.telefono,
    email: this.formProfesor.value.email,
    genero: this.formProfesor.value.genero,
    fechaNacimiento: this.formProfesor.value.fechaNacimiento,
    estado: parseInt(this.formProfesor.value.estado)

 }
 if(this.datosProfesor == null)
  {
    this._profesorServicio.crear(profesor).subscribe({
      next: (data) =>{
        if(data.isExitoso)
       
      {
        this._compartidoServicio.mostrarAlerta('Profesor registrado con exito!',
                                 'Completo');
        this.modal.close("true"); 
      }    
      else
        this._compartidoServicio.mostrarAlerta('No se pudo crear al Medico', 'Error!');
      },
      error: (e) => {
        this._compartidoServicio.mostrarAlerta(e.error.erroes,'Error!');
      }
    });
  }
  else
  {
    this._profesorServicio.editar(profesor).subscribe({
      next: (data) =>{
        if(data.isExitoso)
       
      {
        this._compartidoServicio.mostrarAlerta('Profesor registrado con exito!',
                                 'Completo');
        this.modal.close("true"); 
      }    
      else
        this._compartidoServicio.mostrarAlerta('No se pudo crear al Medico', 'Error!');
      },
      error: (e) => {
        this._compartidoServicio.mostrarAlerta(e.error.erroes,'Error!');
      }
    })

  }
 }

}


