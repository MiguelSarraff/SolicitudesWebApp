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
 profesorNombres: ['',Validators.required],
 profesorApellidos: ['',Validators.required],  
 cedula: ['',Validators.required],
 direccion:['',Validators.required],
 telefono:['',Validators.required],
 email:['',Validators.required],
 genero:['M',Validators.required],
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
          profesorNombres: this.datosProfesor.profesorNombres,
          profesorApellidos: this.datosProfesor.profesorApellidos,
          cedula: this.datosProfesor.cedula,
          direccion: this.datosProfesor.direccion,
          telefono: this.datosProfesor.telefono,
          email: this.datosProfesor.email,
          genero: this.datosProfesor.genero,
          estado: this.datosProfesor.estado.toString()
          
        })
      }
  }

crearModificarProfesor(){

 const profesor: Profesor = {
    id: this.datosProfesor == null ? 0 :this.datosProfesor.id,
    profesorNombres: this.formProfesor.value.profesorNombres,
    profesorApellidos: this.formProfesor.value.profesorApellidos,
    cedula: this.formProfesor.value.cedula,
    direccion: this.formProfesor.value.direccion,
    telefono: this.formProfesor.value.telefono,
    email: this.formProfesor.value.email,
    genero: this.formProfesor.value.genero,
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
        this._compartidoServicio.mostrarAlerta('No se pudo crear el profesor', 'Error!');
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


