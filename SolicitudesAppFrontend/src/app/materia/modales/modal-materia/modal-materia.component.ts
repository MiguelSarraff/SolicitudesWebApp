import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Carrera } from 'src/app/carrera/interfaces/carrera';
import { Materia } from '../../interfaces/materia';
import { MateriaService } from '../../servicios/materia.service';
import { CarreraService } from 'src/app/carrera/servicios/carrera.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';

@Component({
  selector: 'app-modal-materia',
  templateUrl: './modal-materia.component.html',
  styleUrls: ['./modal-materia.component.css']
})
export class ModalMateriaComponent implements OnInit {

  formMateria: FormGroup;
  titulo: string = 'Agregar';
  nombreBoton: string = 'Guardar';
  listaCarreras: Carrera[] = [];


constructor (
  private modal: MatDialogRef<ModalMateriaComponent>,
  @Inject(MAT_DIALOG_DATA) public datosMateria: Materia,
  private fb: FormBuilder,
  private _carreraServicio: CarreraService,
  private _materiaServicio: MateriaService,
  private _compartidoServicio: CompartidoService
) {

  this.formMateria = this.fb.group({
    materiaNombre: ['', Validators.required],
    materiaCodigo: ['',Validators.required],
    materiaCreditos: ['',Validators.required],
    carreraId: ['', Validators.required],
    estado: ['1', Validators.required],

  });
  if (this.datosMateria !=null) {
    this.titulo = 'Editar';
    this.nombreBoton = 'Actualizar';
  }
  this._carreraServicio.lista().subscribe({
    next: (data) => {
      if (data.isExitoso) this.listaCarreras = data.resultado;
    },
    error: (e) => {},
  });
}


ngOnInit(): void {
  if (this.datosMateria != null) {
    this.formMateria.patchValue({
      materiaNombre: this.datosMateria.materiaNombre,
      materiaCodigo: this.datosMateria.materiaCodigo,
      materiaCreditos: this.datosMateria.materiaCreditos, 
      carreraId: this.datosMateria.carreraId,
      estado: this.datosMateria.estado.toString(),
    });
  }
}

crearModificarMateria() {
  const materia: Materia = {
    id: this.datosMateria == null ? 0 : this.datosMateria.id,
    materiaNombre: this.formMateria.value.materiaNombre,
    materiaCodigo: this.formMateria.value.materiaCodigo,
    materiaCreditos: this.formMateria.value.materiaCreditos,
    carreraId: parseInt(this.formMateria.value.carreraId),
    estado: parseInt(this.formMateria.value.estado),
    carreraNombre: '',
  };
  if (this.datosMateria == null) {
    // Crear Materia
    this._materiaServicio.crear(materia).subscribe({
      next: (data) => {
        if (data.isExitoso) {
          this._compartidoServicio.mostrarAlerta(
            'La materia ha sido grabada con Exito!',
            'Completo'
          );
          this.modal.close('true');
        } else
          this._compartidoServicio.mostrarAlerta(
            'No se pudo crear la materia',
            'Error!'
          );
      },
      error: (e) => {
        this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
      },
    });
  } else {
    // Editar/Actualizar Medico
    this._materiaServicio.editar(materia).subscribe({
      next: (data) => {
        if (data.isExitoso) {
          this._compartidoServicio.mostrarAlerta(
            'La materia ha sido actualizada con Exito!',
            'Completo'
          );
          this.modal.close('true');
        } else
          this._compartidoServicio.mostrarAlerta(
            'No se pudo actualizar la materia',
            'Error!'
          );
      },
      error: (e) => {
        this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
      },
    });
  }
}

}
