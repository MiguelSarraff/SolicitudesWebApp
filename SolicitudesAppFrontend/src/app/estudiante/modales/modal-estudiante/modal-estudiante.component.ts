import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Estudiante } from '../../interfaces/estudiante';
import { EstudianteService } from '../../servicios/estudiante.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { Login } from 'src/app/usuario/interfaces/login';


@Component({
  selector: 'app-modal-estudiante',
  templateUrl: './modal-estudiante.component.html',
  styleUrls: ['./modal-estudiante.component.css']
})
export class ModalEstudianteComponent implements OnInit {
 
 
  formEstudiante: FormGroup;
  titulo: string = "Agregar";
  nombreBoton: string = "Guardar";
  listaUsuarios: Login[] = [];
  
  constructor(
    private modal: MatDialogRef<ModalEstudianteComponent>,
    @Inject(MAT_DIALOG_DATA) public datosEstudiante: Estudiante,
    private fb: FormBuilder,
    private _estudianteServicio: EstudianteService,
    private _compartidoServicio: CompartidoService
  ){
    this.formEstudiante = this.fb.group({
   estudianteNombres: ['',Validators.required],
   estudianteApellidos: ['',Validators.required],  
   usuarioId: ['',Validators.required],  
   cedula: ['',Validators.required],
   direccion:['',Validators.required],
   telefono:['',Validators.required],
   email:['',Validators.required],
   genero:['M',Validators.required],
   estado:['1',Validators.required]
  });
  if(this.datosEstudiante !=null)
  { 
     this.titulo ="Editar";
     this.nombreBoton = "Actualizar";
  }
  
  }
  
    ngOnInit(): void {
      if(this.datosEstudiante !=null)
        {
          this.formEstudiante.patchValue({
            estudianteNombres: this.datosEstudiante.estudianteNombres,
            estudianteApellidos: this.datosEstudiante.estudianteApellidos,
            usuarioId: this.datosEstudiante.usuarioId,
            cedula: this.datosEstudiante.cedula,
            direccion: this.datosEstudiante.direccion,
            telefono: this.datosEstudiante.telefono,
            email: this.datosEstudiante.email,
            genero: this.datosEstudiante.genero,
            estado: this.datosEstudiante.estado.toString(),
            
          })
        }
    }
  
  crearModificarEstudiante(){
  
   const estudiante: Estudiante = {
      id: this.datosEstudiante == null ? 0 :this.datosEstudiante.id,
      estudianteNombres: this.formEstudiante.value.profesorNombres,
      estudianteApellidos: this.formEstudiante.value.profesorApellidos,
      usuarioId: parseInt(this.formEstudiante.value.usuarioId),
      cedula: this.formEstudiante.value.cedula,
      direccion: this.formEstudiante.value.direccion,
      telefono: this.formEstudiante.value.telefono,
      email: this.formEstudiante.value.email,
      genero: this.formEstudiante.value.genero,
      estado: parseInt(this.formEstudiante.value.estado),
      nombreUsuario: '',
  
   }
   if(this.datosEstudiante == null)
    {
      this._estudianteServicio.crear(estudiante).subscribe({
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
      //Editar/Actualizar Estudiante
      this._estudianteServicio.editar(estudiante).subscribe({
        next: (data) =>{
          if(data.isExitoso)
         
        {
          this._compartidoServicio.mostrarAlerta('Estudiante registrado con exito!',
                                   'Completo');
          this.modal.close("true"); 
        }    
        else
          this._compartidoServicio.mostrarAlerta('No se pudo crear al Estudiante', 'Error!');
        },
        error: (e) => {
          this._compartidoServicio.mostrarAlerta(e.error.erroes,'Error!');
        }
      })
  
    }
   }
  
 
 
 
 
 
 
 
 
 
 
 
 
  

}
